using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Customers;

namespace Nop.Data.Mapping.Customers
{
    
    public partial class InvoicesMap : NopEntityTypeConfiguration<Invoices>
    {
        #region Methods
        
        public override void Configure(EntityTypeBuilder<Invoices> builder)
        {
            builder.ToTable(NopMappingDefaults.InvoicesTable);
            builder.HasKey(mapping => mapping.Id);
            base.Configure(builder);
        }

        #endregion
    }
}