using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HitExercise.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Η Ονομασία είναι υποχρεωτική")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Η Ονομασία πρέπει να είναι μεταξύ 3 και 80 χαρακτήρων")]
        [DisplayName("*ΟΝΟΜΑΣΙΑ:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Το ΑΦΜ είναι υποχρεωτικό")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Το ΑΦΜ πρέπει να έχει 9 ψηφία")]
        [DisplayName("*ΑΦΜ:")]
        public int Afm { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Η Διεύθυνση πρέπει να είναι μεταξύ 5 και 100 χαρακτήρων")]
        [DisplayName("ΔΙΕΥΘΥΝΣΗ:")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Το Τηλέφωνο είναι υποχρεωτικό")]
        [StringLength(10, ErrorMessage = "Το Τηλέφωνο πρέπει να έχει 10 ψηφία")]
        [DisplayName("ΤΗΛΕΦΩΝΟ:")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Το Email είναι υποχρεωτικό")]
        [EmailAddress(ErrorMessage = "Μη έγκυρη μορφή Email")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Το Email πρέπει να είναι μεταξύ 5 και 50 χαρακτήρων")]
        [DisplayName("*EMAIL:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Το πεδίο 'Ενεργός/Άνεργος προμηθευτής' είναι υποχρεωτικό")]
        public bool IsActive { get; set; }

        //Nav Properties
        [Required(ErrorMessage = "Η επιλογή κατηγορίας είναι υποχρεωτική")]
        [DisplayName("*ΚΑΤΗΓΟΡΙΑ:")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Η επιλογή χώρας είναι υποχρεωτική")]
        [DisplayName("*ΧΩΡΑ:")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
