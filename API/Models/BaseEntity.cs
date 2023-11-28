using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class BaseEntity
{
    public class GeneralModel
    {
        [Key, Column("guid")]
        public Guid Guid { get; set; }

        [Required, Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [Required, Column("modified_date")]
        public DateTime ModifiedDate { get; set; }
    }
}
