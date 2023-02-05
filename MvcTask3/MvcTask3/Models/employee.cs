//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcTask3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class employee
    {
        [DisplayName("First Name")]
        [StringLength(12)]

        [Required(ErrorMessage = " First Name is required")]

        public string first_Name { get; set; }
        [DisplayName("Last Name")]
        [StringLength(12)]
        [Required(ErrorMessage = "Last Name is required")]

        public string last_Name { get; set; }
        [Required(ErrorMessage = "Email  is required")]
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression("((079)|(078)|(077)){1}[0-9]{7}")]
        public string Phone { get; set; }
        [Range(18, 50)]
        public Nullable<int> age { get; set; }

        [DisplayName("Job Title")]
        [StringLength(10)]

        public string Job_Title { get; set; }
        public Nullable<bool> Gender { get; set; }
        public int id { get; set; }
        public string user_image { get; set; }
        public string Cv { get; set; }
    }
}