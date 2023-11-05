using System;
using System.ComponentModel.DataAnnotations;

namespace BrakehillBarnsBooking.Models
{
    public class BookingModel
    {
        [Required]
        [Display(Name = "Check-In Date")]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [Required]
        [Display(Name = "Check-Out Date")]
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        [Required]
        [Display(Name = "Accommodation Type")]
        public string? Accommodation { get; set; }

        [Required]
        [Display(Name = "Number of People")]
        public int NumPeople { get; set; }

        [Display(Name = "Are you bringing dogs?")]
        public bool BringingDogs { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
    }
}
