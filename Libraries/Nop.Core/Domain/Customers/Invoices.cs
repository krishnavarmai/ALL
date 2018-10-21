using System;
using System.Collections.Generic;
using Nop.Core.Domain.Security;

namespace Nop.Core.Domain.Customers
{
    public partial class Invoices : BaseEntity
    {
        public string UserName { get; set; }
        public string InvoiceNum { get; set; }
        public DateTime? InvDate { get; set; }
        public decimal? Amount { get; set; }
        public int? StatusId { get; set; }
    }
}