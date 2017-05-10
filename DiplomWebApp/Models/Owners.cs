using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiplomWebApp.Models
{
    public class Owners
    {
        public int Id { get; set; }
        [Display(Name = "Фірма")]
        public int FirmId { get; set; }

        [Display(Name = "Власник")]
        public string Owner { get; set; }
        [Display(Name = "Номер поста")]
        public string PostNumber { get; set; }
        [Display(Name = "Номер телефону")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Фірма")]
        public virtual Firms Firms { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}