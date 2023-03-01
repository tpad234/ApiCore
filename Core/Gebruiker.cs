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
       // readonly IGebruikerDal IgebruikerDal;
        string Naam { get; }
        private string Email { get; }
        string Wachtwoord { get; }
        private Rol Rol { get; }

    }
}
