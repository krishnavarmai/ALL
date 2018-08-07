using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// Represents a CustomerBillToMapping mapping class
    /// </summary>
    public partial class BillToShipToMapping : BaseEntity
    {
       
        public int ShipToId { get; set; }
        public int BillToId { get; set; }

       
        public virtual BillTo BillTo { get; set; }

        public virtual ShipTo ShipTo { get; set; }
        
    }
}