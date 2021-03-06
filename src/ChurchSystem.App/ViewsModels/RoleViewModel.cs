﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChurchSystem.App.ViewsModels
{
    public class RoleViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(200, ErrorMessage = "The {0} field must be between {2} and {1} characters.", MinimumLength = 2)]
        public string Description { get; set; }

        public IEnumerable<MemberViewModel> Members { get; set; }
    }
}
