using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Safari_Wave.Models.DTOs
{
    public class GetPackageDto
    {
        
        public int PackId { get; set; }
        
        public string PackageName { get; set; } = null!;

        public string? Describtion { get; set; }
        
        public int Duration { get; set; }
        
        public string Location { get; set; } = null!;

        public string? Facilities { get; set; }
        public decimal PricePerHead { get; set; }
        public decimal OfferPrice { get; set; }
        public int MinNoOfPerson { get; set; }

        public string? Type { get; set; }

        //public int? AdditionPricePerson { get; set; }

        public int? NoOfCustomers { get; set; }

        public string? CoverImage { get; set; }

        public string? Country { get; set; }

        public string? Image1 { get; set; }

        public string? Image2 { get; set; }

        public string? Image3 { get; set; }

        public string? Image4 { get; set; }
    }
}
