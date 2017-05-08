using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomWebApp.Models
{
    public class OwnersDTO
    {
        public int Id { get; set; }
        public int FirmId {get;set;}
        public string Name { get; set; }

        public string Telephone { get; set; }


        public string Code { get; set; }
    }
}