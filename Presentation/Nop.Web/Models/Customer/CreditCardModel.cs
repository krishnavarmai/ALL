using System;
using System.Collections.Generic;
using Nop.Core.Domain.Orders;
using Nop.Web.Framework.Models;

namespace Nop.Web.Models.Order
{
    public partial class CreditCardModel 
    {
        public string InvoiceIds { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
    }
}