﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
