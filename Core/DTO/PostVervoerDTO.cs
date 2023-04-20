using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class PostVervoerDTO
    {
        public int ItemId { get; set; }
        public int VerzenderId { get; set; }
        public int OntvangerId { get; set; }
        public PostVervoerDTO(int ItemID, int verzenderId, int ontvangerid)
        {
            this.ItemId = ItemID;
            this.VerzenderId = verzenderId;
            this.OntvangerId = ontvangerid;



        }
    }
}

