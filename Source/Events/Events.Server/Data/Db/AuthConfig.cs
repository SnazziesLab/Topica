using System.ComponentModel.DataAnnotations;

namespace Events.Server.Data.Db;


public class AuthConfig
{
    public ApiKeyConfig[] ApiKeys { get; set; }
    public UserConfig[] Users { get; set; }
}


public class ApiKeyConfig
{
    [Key]
    public string ApiKey { get; set; }
    public string[] Roles { get; set; }
}