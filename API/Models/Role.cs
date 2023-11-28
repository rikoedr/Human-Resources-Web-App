using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_roles")]
public class Role
{
    [Required, Column("name", TypeName = "nvarchar(20)")]
    public string Name { get; set; }

    // Table cardinality
    public IEnumerable<AccountRole>? AccountRoles { get; set; }
}
