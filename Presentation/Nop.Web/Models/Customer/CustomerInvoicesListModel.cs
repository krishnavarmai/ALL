using System;
using System.Collections.Generic;
using Nop.Core.Domain.Orders;
using Nop.Web.Framework.Models;

namespace Nop.Web.Models.Order
{
    public partial class CustomerInvoicesListModel : BaseSearchModel
    {
        public CustomerInvoicesListModel()
        {
            InvoicesList = new List<Invoices>();
        }

        public IList<Invoices> InvoicesList { get; set; }

        public int InvoiceId { get; set; }
        #region Nested classes
        public int? PageSize { get; set; }
        public partial class Invoices : BaseNopEntityModel
        {
            public string InvoiceNum { get; set; }
            public DateTime? InvDate { get; set; }
            public decimal? Amount { get; set; }
            public string Status { get; set; }
        }

        
        #endregion
    }
}