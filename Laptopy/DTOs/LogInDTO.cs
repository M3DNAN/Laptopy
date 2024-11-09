﻿using System.ComponentModel.DataAnnotations;

namespace Laptopy.DTOs
{
    public class LogInDTO
    {
        public int Id { get; set; }       
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}