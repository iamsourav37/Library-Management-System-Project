﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Web.Models.ViewModel.Account
{
    public class UserEditViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Address1 { get; set; }
        public List<SelectListItem>? RoleList { get; set; }

        [Required]
        public string SelectedRole { get; set; }
    }
}
