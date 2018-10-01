using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Catalog;


namespace Nop.Data.Mapping.Catalog
{
    /// <summary>
    /// Represent a review type mapping class
    /// </summary>
    public partial class CategoryCodeDiscountsMap : NopEntityTypeConfiguration<CategoryCodeDiscounts>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<CategoryCodeDiscounts> builder)
        {
            builder.ToTable(nameof(CategoryCodeDiscounts));
            builder.HasKey(category => category.Id);
            builder.Property(product => product.ShipTo);
            builder.Property(product => product.CategoryCode);
            builder.Property(product => product.DiscountValue);
            base.Configure(builder);
        }

        #endregion
    }
}
