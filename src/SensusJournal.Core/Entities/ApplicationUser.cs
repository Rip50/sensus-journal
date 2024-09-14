using Microsoft.AspNetCore.Identity;

namespace SensusJournal.Core.Entities;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
}
