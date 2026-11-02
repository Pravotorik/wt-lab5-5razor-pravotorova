namespace wt_lab8_8razor_postgresql_pravotorova.Models;

public class Guest
{
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Country { get; set; } = "";
    public string AvatarUrl { get; set; } = "";
}