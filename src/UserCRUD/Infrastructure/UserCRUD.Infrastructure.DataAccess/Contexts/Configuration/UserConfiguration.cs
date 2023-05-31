using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCRUD.Infrastructure.DataAccess.Contexts.Configuration
{
    using User = Domain.User.User;
    /// <summary>
    /// Конфигурация сущности пользователя
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Guid);
            builder.Property(a => a.Login).HasMaxLength(256).IsRequired();
            builder.Property(a => a.Password).HasMaxLength(256).IsRequired();
            builder.Property(a => a.Gender).IsRequired();
            builder.Property(a => a.Birthday).IsRequired(false);
            builder.Property(a => a.Admin).IsRequired();
            builder.Property(a => a.CreatedOn).HasConversion(s => s, s => DateTime.SpecifyKind(s, DateTimeKind.Utc)).IsRequired(false);
            builder.Property(a => a.CreatedBy).IsRequired(false);
            builder.Property(a => a.ModifiedOn).HasConversion(s => s, s => DateTime.SpecifyKind(s, DateTimeKind.Utc)).IsRequired(false);
            builder.Property(a => a.ModifiedBy).IsRequired(false);
            builder.Property(a => a.RevokedOn).HasConversion(s => s, s => DateTime.SpecifyKind(s, DateTimeKind.Utc)).IsRequired(false);
            builder.Property(a => a.RevokedBy).IsRequired(false);
        }
    }
}
