using System.ComponentModel.DataAnnotations;

public class ContactMessageModel
{
    [Required(ErrorMessage = "Please enter your name.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Please enter your email.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Please enter your message.")]
    public string? Message { get; set; }
}
