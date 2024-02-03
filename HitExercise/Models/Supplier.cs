using System.ComponentModel.DataAnnotations;

namespace HitExercise.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public int Afm { get; set; }
        public string Adress { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        //Nav Properties
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
