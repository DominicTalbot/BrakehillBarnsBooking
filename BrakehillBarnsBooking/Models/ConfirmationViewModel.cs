using System;
using System.ComponentModel.DataAnnotations;

namespace BrakehillBarnsBooking.Models
{
    public class ConfirmationViewModel
    {
        [Required(ErrorMessage = "Please enter the Check-In Date.")]
        [Display(Name = "Check-In Date")]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = "Please enter the Check-Out Date.")]
        [Display(Name = "Check-Out Date")]
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        [Required(ErrorMessage = "Please select an Accommodation Type.")]
        [Display(Name = "Accommodation Type")]
        public string? Accommodation { get; set; }

        [Required(ErrorMessage = "Please enter the Number of People.")]
        [Display(Name = "Number of People")]
        public int NumPeople { get; set; }

        [Display(Name = "Are you bringing dogs?")]
        public bool BringingDogs { get; set; }

        [Required(ErrorMessage = "Please enter your Name.")]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter a valid Email address.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter a valid Phone Number.")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
    }
}
