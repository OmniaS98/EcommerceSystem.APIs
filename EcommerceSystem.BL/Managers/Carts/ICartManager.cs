using EcommerceSystem.BL.DTOs.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BL.Managers.Carts;

public interface ICartManager
{
    public void AddItem(string userId, CartItemDTO  cartItemDto);
    public void RemoveItem(string userId, int itemId);
    public void EditItemQuantity(string userId, CartItemDTO cartItemDto);
}
