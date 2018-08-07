using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// Represents a CustomerBillToMapping mapping class
    /// </summary>
    public partial class CustomerBillToMapping : BaseEntity
    {
       
        public int CustomerId { get; set; }
        public int BillToId { get; set; }

       
        public virtual BillTo BillTo { get; set; }

        public virtual Customer Customer { get; set; }
        
    }
}