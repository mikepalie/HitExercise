using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HitExercise.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public int CategoryCode { get; set; }
        public string Name { get; set; }

        //Nav Property
        public ICollection<Supplier> Suppliers { get; set; }


    }
}
