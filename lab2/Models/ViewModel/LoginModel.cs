﻿using System.ComponentModel.DataAnnotations;

namespace lab2.Models.ViewModel
{
				public class LoginModel
				{
								[Required]
								public string Name { get; set; }

								[Required]
								[UIHint("password")]
								public string Password { get; set; }

								public string ReturnUrl { get; set; } = "/";
				}
}
