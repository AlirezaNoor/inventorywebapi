using System.Globalization;
using Microsoft.AspNetCore.Identity;

namespace INV.Domin;

public class ApplicationUser : IdentityUser<string>
{
    public string FirstName { get; set; }
    public string Lastname { get; set; }
    public string melicode { get; set; }
    public string personalcode { get; set; }
    public DateTime Birthday { get; set; }

    public bool Gender { get; set; }
    //1=admin
    //2=user
    public byte UserType { get; set; }
}