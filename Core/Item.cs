using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }

        public int EigenaarId { get; set; }
        public Gebruiker Eigenaar { get; set; }
        public Status status { get; set; }
    }
}