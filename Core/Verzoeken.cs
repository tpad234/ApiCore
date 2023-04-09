using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Verzoeken
    {
        [Key]
        public int Id { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int VerzenderId { get; set; }
        public Gebruiker Verzender { get; set; }
        public int OntvangerId { get; set; }
        public Gebruiker Ontvanger { get; set; }

        public Status status { get; set; }
    }
}
