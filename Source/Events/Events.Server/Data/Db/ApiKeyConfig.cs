using System.ComponentModel.DataAnnotations;

namespace Events.Server.Data.Db;

public class ApiKeyConfig
{
    [Key]
    public required string ApiKey { get; set; }
    public required string[] Roles { get; set; }
}