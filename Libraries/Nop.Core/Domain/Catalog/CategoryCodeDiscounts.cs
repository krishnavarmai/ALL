using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;
namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// Represents a product Current mapping
    /// </summary>
    public partial class CategoryCodeDiscounts : BaseEntity, ILocalizedEntity
    {
        
        public int ShipTo { get; set; }
       
        public string CategoryCode { get; set; }

        public double DiscountValue { get; set; }
        
    }
}
