﻿using System.ComponentModel.DataAnnotations;

namespace WebMVC.ViewModels;

public class LoginViewModel
{
    [Required]
    [DataType(DataType.Text)]
    public string Username { get; set; } = "";

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; } = false;
}
