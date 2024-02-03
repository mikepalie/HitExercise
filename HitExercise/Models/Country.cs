using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HitExercise.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public int CountryCode { get; set; }
        public string Name { get; set; }

        //Nav property
        public ICollection<Supplier> Suppliers { get; set; }


    }
}
