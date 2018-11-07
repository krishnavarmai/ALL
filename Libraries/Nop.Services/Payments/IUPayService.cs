using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;

namespace Nop.Services.Payments
{
    /// <summary>
    /// Payment service interface
    /// </summary>
    public interface IUPayService
    {

        Tuple<string, bool> ApplyCreditCardDetails(string cardNo, int expMonth, int expYear, string cvv, string poRefNo, string Email, double amount);

    }
}