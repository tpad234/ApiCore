using Core.DTO;
using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core
{
    public class Item
    {
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public Gebruiker Eigenaar { get; set; }
        public Status status { get; set; }

        public Item(ItemDTO itemDTO)
        { 
            Code = itemDTO.Code;
            Naam= itemDTO.Naam;
            Beschrijving = itemDTO.Beschrijving;
            Eigenaar  = new Gebruiker(itemDTO.Eigenaar);
            status =  itemDTO.status;
        }
    }
}