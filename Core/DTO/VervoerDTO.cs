using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class VervoerDTO
    {
        public int Id { get; set; }

        public int ItemId { get; set; }
        public ItemDTO Item { get; set; }
        public int VerzenderId { get; set; }
        public GetGebruikerDTO Verzender { get; set; }
        public int OntvangerId { get; set; }
        public GetGebruikerDTO Ontvanger { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Status status { get; set; }

        public VervoerDTO(int Id, int ItemID, ItemDTO item, int verzenderId, GetGebruikerDTO verzender, int ontvangerid, GetGebruikerDTO ontvanger, Status status)
        {
            this.Id = Id;
            this.ItemId = ItemID;
            this.Item = item;
            this.VerzenderId = verzenderId;
            this.Verzender = verzender;
            this.OntvangerId = ontvangerid;
            this.Ontvanger = ontvanger;
            this.status = status;


        }
    }

}
