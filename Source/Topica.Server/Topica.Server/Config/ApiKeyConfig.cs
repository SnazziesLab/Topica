using System.ComponentModel.DataAnnotations;

namespace Events.Server.Config;

public class ApiKeyConfig
{
    [Key]
    public required string ApiKey { get; set; }
    public required string[] Roles { get; set; }
}