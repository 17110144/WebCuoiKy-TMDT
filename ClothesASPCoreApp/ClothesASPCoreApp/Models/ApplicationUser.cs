﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesASPCoreApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Tên nhân viên")]
        public string Name { get; set; }
        [NotMapped]
        public bool IsSuperAdmin { get; set; }
    }
}
