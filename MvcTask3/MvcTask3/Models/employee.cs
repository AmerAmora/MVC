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
    
    public partial class employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employee()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public string first_Name { get; set; }
        public string last_Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<int> age { get; set; }
        public string Job_Title { get; set; }
        public Nullable<bool> Gender { get; set; }
        public int id { get; set; }
        public string user_image { get; set; }
        public string Cv { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
