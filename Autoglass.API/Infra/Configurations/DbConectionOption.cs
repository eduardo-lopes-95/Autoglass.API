namespace Autoglass.API.Infra.Configurations;

public class DbConectionOption
{
    public const string SECTION_KEY = "DbConectionOption";
    public string AutoglassConnection { get; set; } = string.Empty;
}
