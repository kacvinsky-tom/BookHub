using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Entity;

public class LocalIdentityUser : IdentityUser
{
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }
}
