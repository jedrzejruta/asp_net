﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace lab2.Models
{
				public class AppDbContext : IdentityDbContext<IdentityUser>
				{
								public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
								{
								}
								public DbSet<Product> Products { get; set; }
				}
}