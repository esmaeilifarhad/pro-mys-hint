using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.MYS.Domains
{
    public class Hint : BaseEntity
    {
        public DateTime? RefreshDate { get; set; }
        //[MaxLength(3000)]
        public string Description { get; set; }
    }

    public class HintConfiguration : IEntityTypeConfiguration<Hint>
    {
        public void Configure(EntityTypeBuilder<Hint> builder)
        {

            builder.Property(x => x.Description).HasMaxLength(3000).IsRequired(false);
            //builder.HasOne(q => q.MasterData).
            //    WithMany(q => q.Matches).
            //    HasForeignKey(q => q.MasterDataId).
            //    OnDelete(DeleteBehavior.Cascade);


        }
    }

}
