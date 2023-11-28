﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace API.Models;

[Table("tb_account_roles")]
public class AccountRole : BaseEntity
{
    [Required, Column("account_guid")]
    public Guid AccountGuid { get; set; }

    [Required, Column("role_guid")]
    public Guid RoleGuid { get; set; }

    // Table Cardinality
    public Account? Account { get; set; }
    public Role? Role { get; set; }
}
