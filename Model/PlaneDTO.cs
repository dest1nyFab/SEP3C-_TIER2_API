using System.ComponentModel.DataAnnotations;

namespace SEP3_TIER2_API.Model
{
    public class PlaneDTO
    {
        [Key]
        public string CallSign { get; set; }
        public string Model { get; set; }
        public string Company { get; set; }
        public override string ToString()
        {
            return $"CallSign: {CallSign} \nModel:{Model} \nCompany: {Company}";
        }
    }
}
