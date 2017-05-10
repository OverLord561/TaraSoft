using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiplomWebApp.Models
{
    public class Products
    {
        public int Id { get; set; }
        [Display(Name = "Власник")]
        public int OwnerId { get; set; }
        [Display(Name = "Назва")]
        public string ProductName { get; set; }
        [Display(Name = "Код")]
        public string ProductCode { get; set; }
        [Display(Name = "Об'єм")]
        public string ProductValue { get; set; }
        [Display(Name = "Податок")]
        public string ProductToll { get; set; }
        [Display(Name = "Тип")]
        public string stage { get; set; }
        [Display(Name = "Митниця оформлення")]
        public string CustomsDecorated_ { get; set; }
        [Display(Name = "Час оформлення")]
        public Nullable<System.DateTime> Date { get; set; }

        [Display(Name = "Країна відправлення")]
        public string StartCountry { get; set; }
        [Display(Name = "Країна призначення")]
        public string FinishCountry { get; set; }
        [Display(Name = "Власник")]
        public virtual Owners Owners { get; set; }
    }
}