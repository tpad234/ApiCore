using Core.DTO;
using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Gebruiker
    {
        string Naam { get; }
        private string Email { get; }
        string Wachtwoord { get; }
        private Rol Rol { get; }

        public Gebruiker(GebruikerDTO gebruikerDTO)
        {
            Naam = gebruikerDTO.Naam;
            Email = gebruikerDTO.Email;
            Wachtwoord = gebruikerDTO.Wachtwoord;
            Rol = gebruikerDTO.Rol;
        }

    }


}
