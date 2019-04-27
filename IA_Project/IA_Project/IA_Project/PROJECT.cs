//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IA_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class PROJECT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROJECT()
        {
            this.ACTOR_PROJECT = new HashSet<ACTOR_PROJECT>();
        }
    
        public int PROJECT_ID { get; set; }
        [Required(ErrorMessage ="You Have TO Enter Project Name .")]
        [Display(Name ="Project Name")]
        public string NAME_PROJECT { get; set; }
        [Required(ErrorMessage = "You Have TO Enter Project Description .")]
        [Display(Name = "Project Description")]
        public string DESC_PROJECT { get; set; }
        [Display(Name = "Project State")]
        public bool P_STATUS { get; set; }
        [Required(ErrorMessage = "You Have TO Enter Project Start Date .")]
        [Display(Name = "Start Date")]
        public System.DateTime START_TIME { get; set; }
        [Required(ErrorMessage = "You Have TO Enter Project End Date .")]
        [Display(Name = "End Date")]
        public System.DateTime END_TIME { get; set; }
        [Required(ErrorMessage = "You Have TO Enter Project Price .")]
        [Display(Name = "Price")]
        public int PRICE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACTOR_PROJECT> ACTOR_PROJECT { get; set; }
    }
}
