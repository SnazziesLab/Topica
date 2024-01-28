using System.ComponentModel.DataAnnotations;

public record UserConfig
{
    [Key]
    public int Id {get;set;}
    public required string Username { get; set; }
    public required string Password { get; set; }
    public string[] Roles { get; set; }
}