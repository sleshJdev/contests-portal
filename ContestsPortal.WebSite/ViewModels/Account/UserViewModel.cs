﻿using ContestsPortal.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContestsPortal.WebSite.ViewModels.Account
{
    public class UserViewModel
    {
        public UserProfile User;
                
        public UserViewModel()
        {
            User = new UserProfile();
        }
        
        public UserViewModel(Domain.Models.UserProfile userProfile)
        {
            User = userProfile;
        }

        [Editable(false)]
        [HiddenInput(DisplayValue = false)]
        public int? Id { set; get; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "UserNameIsRequired")]
        [Display(ResourceType = typeof(CommonResources), Name = "Username")]
        [Remote("VerificateUserName", "Verification", HttpMethod = "post", ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "UniqueUserName")]
        public string UserName { get { return User.UserName; } set { User.UserName = value; } }        

        [Remote("VerificateUserNickName", "Verification", HttpMethod = "POST", ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "UniqueNickName")]
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "NickNameIsRequired")]
        [Display(ResourceType = typeof(CommonResources), Name = "Nickname")]
        public string NickName { get { return User.NickName; } set { User.NickName = value; } }

        [Remote("VerificateUserEmail", "Verification", HttpMethod = "POST", ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "UniqueEmail")]
        [Display(ResourceType = typeof(CommonResources), Name = "Email")]
        public string Email { get { return User.Email; } set { User.Email = value; } }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "PasswordIsRequired")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(CommonResources), Name = "Password")]
        public string Password { get; set; }

        [Display(ResourceType = typeof(CommonResources), Name = "PasswordConfirmation")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessageResourceType = typeof(ValidationResources),
            ErrorMessageResourceName = "PasswordConfDoesntFit")]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }
    }
}