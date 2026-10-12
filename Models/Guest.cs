using System.ComponentModel.DataAnnotations;

namespace wt_lab5_5razor_pravotorova.Models;

public class Guest
{
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
}