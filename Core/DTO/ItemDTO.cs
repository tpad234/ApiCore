using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public int EigenaarId { get; set; }
        public GetGebruikerDTO Eigenaar { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Status status { get; set; }

    public ItemDTO(int Id, string Code,string Naam, string bestrijving, int EigenaarId, GetGebruikerDTO Eigenaar, Status status)
        {
            this.Id = Id;
            this.Code = Code;
            this.Naam = Naam;
            this.Beschrijving = bestrijving;
            this.EigenaarId = EigenaarId;
            this.Eigenaar = Eigenaar;
            this.status = status;

        }
    }
}
