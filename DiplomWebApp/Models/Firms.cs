using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiplomWebApp.Models
{
    public class Firms
    {
        public int Id { get; set; }
        [Display(Name = "Фірма")]
        public string NameFirm { get; set; }
        [Display(Name = "Адреса")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        [Display(Name = "Код")]
        public string Code { get; set; }

        public virtual ICollection<Owners> Owners { get; set; }
    }
}