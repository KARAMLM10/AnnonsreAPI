using System.ComponentModel.DataAnnotations;

namespace AnnonsreAPI.Model
{
    public class Annons
    {
        [Key]
        public int AnnonsId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string City { get; set; }

    }
}
