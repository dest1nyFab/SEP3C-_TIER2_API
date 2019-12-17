using System.ComponentModel.DataAnnotations;

namespace SEP3_TIER2_API.DTO
{
    public class PlaneDTO
    {
        [Key]
        public string RegistrationNo { get; set; }
        public string Model { get; set; }
        public string Company { get; set; }
        public string Status { get; set; }
        public override string ToString()
        {
            return $"RegistrationNo: {RegistrationNo} \nModel:{Model} \nCompany: {Company}";
        }
    }
}
