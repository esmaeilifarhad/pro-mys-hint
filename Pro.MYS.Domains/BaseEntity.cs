using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.MYS.Domains
{
    public abstract class BaseEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }

        public DateTime? Created { get; set; } = DateTime.Now;
        [MaxLength(50)]
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; } = DateTime.Now;
        [MaxLength(50)]
        public string? LastModifiedBy { get; set; }
        public bool? IsDeleted { get; set; } = false;
        [MaxLength(10)]
        public string? Time { get; set; }
        [MaxLength(500)]
        public string? Title { get; set; }
    }
    public abstract class BaseEntity : BaseEntity<long>
    {

    }
}
