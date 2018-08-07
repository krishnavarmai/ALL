using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Customers;

namespace Nop.Data.Mapping.Customers
{
    /// <summary>
    /// Represents a customer-address mapping configuration
    /// </summary>
    public partial class CustomerBillToMap : NopEntityTypeConfiguration<CustomerBillToMapping>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<CustomerBillToMapping> builder)
        {
            builder.ToTable(NopMappingDefaults.CustomerBillToTable);
            builder.HasKey(mapping => mapping.Id);
            builder.Property(mapping => mapping.CustomerId).HasColumnName("Customer_Id");
            builder.Property(mapping => mapping.BillToId).HasColumnName("BillTo_Id");

            builder.HasOne(mapping => mapping.Customer)
                .WithMany(customer => customer.CustomerBillToMappings)
                .HasForeignKey(mapping => mapping.CustomerId)
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