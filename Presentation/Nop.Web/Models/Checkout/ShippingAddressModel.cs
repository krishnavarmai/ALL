using System.Collections.Generic;
using Nop.Core.Domain.Common;
using Nop.Web.Framework.Models;
using Nop.Web.Models.Common;

namespace Nop.Web.Models.Checkout
{
    public partial class ShippingAddressModel : BaseNopModel
    {
        public ShippingAddressModel()
        {
            ShipTos = new List<ShipTo>();
            CurrentShipTo = new ShipTo();
        }
        public IList<ShipTo> ShipTos { get; set; }
        public ShipTo CurrentShipTo { get; set; }
    }
}