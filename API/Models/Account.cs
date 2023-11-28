using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

[Table("tb_accounts")]
public class Account : BaseEntity
{
    [Required, Column("password", TypeName = "nvarchar(max)")]
    public string Password { get; set; }

    [Required, Column("is_disabled")]
    public bool IsDisabled { get; set; }

    [Required, Column("otp")]
    public int OTP { get; set; }

    [Required, Column("is_otp_used")]
    public bool IsOtpUsed { get; set; }

    [Required, Column("otp_expired_time")]
    public DateTime OtpExpiredTime { get; set; }

    // Table cardinality
    public Employee? Employee { get; set; }
    public IEnumerable<AccountRole>? AccountRoles { get; set; }
}
