﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BL.DTOs.Customers;

public record TokenDTO (string Token, DateTime ExpiryDate);
