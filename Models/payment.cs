using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class payment
    {
        public int id { get; set; }
        public string name { get; set; }

        [MaxLength(37)]
        public string description { get; set; }



        //navigation property
        public ICollection<Client> Clients { get; set; }
    }
}
