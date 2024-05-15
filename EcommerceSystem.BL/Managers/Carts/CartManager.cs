using EcommerceSystem.BL.DTOs.Carts;
using EcommerceSystem.BL.Managers.Products;
using EcommerceSystem.DAL;
using EcommerceSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EcommerceSystem.BL.Managers.Carts;

public class CartManager : ICartManager
{
    private readonly IUnitOfWork _unitOfWork;

    public CartManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    /* --  Add-To-Cart  -- */
    public void AddItem(string userId, CartItemDTO cartItemDto)
    {
        var userCart = _unitOfWork.CartRepository.GetByCustomerId(userId);

        var product = _unitOfWork.ProductRepository.GetById(cartItemDto.ProductId);
        if (product == null)
            throw new Exception("No product with provided id");

        //Check product availability
        var isAvailable = IsProductAvailable(product, cartItemDto.Quantity);
        if (!isAvailable.available)
            throw new Exception(isAvailable.message);


        if (userCart == null)
        {
            //Make new cart
            userCart = new Cart
            {
                CustomerId = userId,
                Items = new List<CartItem>()
            };


            // Add item to cart
            userCart.Items.Add(new CartItem
            {
                ProductId = cartItemDto.ProductId,
                Quantity = cartItemDto.Quantity
            });

            _unitOfWork.CartRepository.Add(userCart);
            _unitOfWork.SaveChanges();
            return;
        }

        // If the item doesn't exist in the cart
        var existingItem = userCart.Items.FirstOrDefault(i => i.ProductId == cartItemDto.ProductId);


        if (existingItem == null)
        {

            userCart.Items.Add(new CartItem
            {
                ProductId = cartItemDto.ProductId,
                Quantity = cartItemDto.Quantity
            });
        }
        else
        {
            // If the item already exists in the cart

            existingItem!.Quantity += cartItemDto.Quantity;
        }

        _unitOfWork.SaveChanges();
    }


    /* --  Update item quantity  -- */
    public void EditItemQuantity(string userId, CartItemDTO updatedCartItemDto)
    {
        //Get user cart by id
        var userCart = _unitOfWork.CartRepository.GetByCustomerId(userId);
        //Search for item in the cart 
        var cartItem = userCart!.Items.FirstOrDefault(i => i.ProductId == updatedCartItemDto.ProductId);
        if (cartItem == null)
        {
            throw new Exception("No item found with provided id");
        }

        //Get product that matches item in the cart to update its quantity
        var product = _unitOfWork.ProductRepository.GetById(cartItem.ProductId);

        //Check product availability
        var isAvailable = IsProductAvailable(product!, updatedCartItemDto.Quantity);
        if (!isAvailable.available)
        {
            throw new Exception(isAvailable.message);
        }   

        cartItem.Quantity = updatedCartItemDto.Quantity;
        
        //If quantity of item becomes zero is removed from items list
        if(cartItem.Quantity == 0) 
        { 
            userCart.Items.Remove(cartItem);
        }

        _unitOfWork.SaveChanges();
    }


    /* --  Remove item  -- */
    public void RemoveItem(string userId, int itemId)
    {
        //Get user cart by id
        var userCart = _unitOfWork.CartRepository.GetByCustomerId(userId);
        //Search for item in the cart 
        var cartItem = userCart!.Items.FirstOrDefault(i => i.ProductId == itemId);
        if(cartItem == null)
        {
            new Exception("No item found with provided id");
            return;
        }

        var product = _unitOfWork.ProductRepository.GetById(cartItem.ProductId);
        userCart.Items.Remove(cartItem);
        _unitOfWork.SaveChanges();
    }


    private (bool available, string message) IsProductAvailable(Product product, int requiredQuantity)
    {
        if (product.Quantity == 0)
            return (false, "Out of stock");
        else if (product.Quantity < requiredQuantity)
            return (false, $"Quantity exceeds the available stock. Available quantity: {product.Quantity} units");

        return (true, "");
    }
}
