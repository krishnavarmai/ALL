using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Customers;

namespace Nop.Data.Mapping.Customers
{
    /// <summary>
    /// Represents a customer-address mapping configuration
    /// </summary>
    public partial class BillToShipToMap : NopEntityTypeConfiguration<BillToShipToMapping>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<BillToShipToMapping> builder)
        {
            builder.ToTable(NopMappingDefaults.BillToShipToTable);
            builder.HasKey(mapping => mapping.Id);
            builder.Property(mapping => mapping.ShipToId).HasColumnName("ShipTo_Id");
            builder.Property(mapping => mapping.BillToId).HasColumnName("BillTo_Id");

            builder.HasOne(mapping => mapping.ShipTo)
                .WithMany()
                .HasForeignKey(mapping => mapping.ShipToId)
                .IsRequired();

            builder.HasOne(mapping => mapping.BillTo)
                .WithMany()
                .HasForeignKey(mapping => mapping.BillToId)
                .IsRequired();

            base.Configure(builder);
        }

        #endregion
    }
}