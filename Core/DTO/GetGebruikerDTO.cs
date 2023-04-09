using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class GetGebruikerDTO
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public Rol Rol { get; set; }

        public GetGebruikerDTO(int Id, string Naam, string Email, Rol Rol)
        {
            this.Id = Id;
            this.Naam = Naam;
            this.Email = Email;
            this.Rol = Rol;

        }
    }
}
