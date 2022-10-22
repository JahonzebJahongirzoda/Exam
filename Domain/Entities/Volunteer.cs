using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace Domain.Entities;

public class Volunteer
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; }
    [Required, MaxLength(100)]
    public string EmailAddress { get; set; }
    [Required, MaxLength(100)]
    public string PhoneNumber { get; set; }
    [Required, MaxLength(100)]
    public string Address { get; set; }
    [Required, MaxLength(100)]
    public string Occupation { get; set; }
    [Required, MaxLength(400)]
    public string YourMessage { get; set; }
}