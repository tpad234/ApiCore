using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class ItemDTO
    {
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public GebruikerDTO Eigenaar { get; set; }
        public Status status { get; set; }

        public ItemDTO(string Code, string Naam, string Beschrijving, GebruikerDTO Eigenaar, Status status)
        {

            this.Code = Code;
            this.Naam = Naam;
            this.Beschrijving = Beschrijving;
            this.Eigenaar = Eigenaar;
            this.status = status;


        }
    }
}
