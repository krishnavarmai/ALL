using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Payments;
using Nop.Core.Infrastructure;
using Nop.Services.Catalog;
using Nop.Services.Configuration;
using Nop.Services.Orders;
using Nop.Services.Plugins;
using UPayServiceReference;
using static UPayServiceReference.TransactionServiceClient;

namespace Nop.Services.Payments
{
    /// <summary>
    /// Payment service
    /// </summary>
    public partial class UPayService : IUPayService
    {
        #region Fields
        private readonly TransactionServiceClient trSvcClient;
        #endregion

        #region Ctor

        public UPayService()
        {
            trSvcClient = new TransactionServiceClient(EndpointConfiguration.BasicHttpBinding_ITransactionService);
        }

        #endregion


        public Tuple<string, bool> ApplyCreditCardDetails(string cardNo, int expMonth, int expYear, string cvv, string poRefNo, string Email, double amount)
        {
            Tuple<string, bool> retVal = new Tuple<string, bool>("Not Started", false);
            //
            UPayServiceReference.UPayAuthNPurchaseRequest authRequestWithCC = new UPayAuthNPurchaseRequest();
            UPayServiceReference.UPayRequestHeader header = new UPayRequestHeader();
            //UPayServiceReference.UPayRequestLine requestLine = new UPayRequestLine();
            //requestLine.ItemDescription = "test visa card";

            string actualCardNo = cardNo.Replace("-", "");
            header.Card_no = actualCardNo; //test visa card - "4112344112344113"
            header.Expiry_Month = expMonth.ToString().PadLeft(2, '0');
            header.Expiry_Year = expYear.ToString();
            header.Cvv_code = cvv;
            header.Total_amount = amount.ToString("0.00");//Unipay expects amount in 0.00 format
            header.Store_receipt = poRefNo;//Store receipt maps to PO Ref# (This should be unique)
            header.TransactionReference2 = Email;//using Reference2 field for EmailId or Fax#
            header.Zipcode = "11111";//Passing dummy zip code to enable zero dollar auth (for Add Card) for AMEX
            //header.Email_id = cccVM.EmailIdOrFax; //header.EmailId is not reaching orbital for some reason
            authRequestWithCC.Header = header;
            
            string BUKey = "0001"; //"0001" for USA or "0002" for Canada
            
            UPayResponse authResponse = Task.Run(async () => await trSvcClient.CreateTokenAndAuthorizeAsync(BUKey, authRequestWithCC)).Result;


            //if (authResponse.ResponseCode.Equals("0"))
            if (authResponse != null && authResponse.Subcode != null && authResponse.Subcode.Equals("1"))
            {
                retVal = new Tuple<string, bool>(authResponse.RequestId, true);
            }
            else
            {
                retVal = new Tuple<string, bool>(authResponse.RequestId, false);
            }


            //resp.AccountNo = authResponse.AccountNumber;
            //resp.TokenKey = authResponse.TokenKey;
            //resp.ReasonCode = authResponse.ReasonCode;//"cc SUCSESS";
            //resp.ResponseCode = authResponse.ResponseCode;//"cc SUCSESS";
            //resp.ReturnDescription = authResponse.ReturnDescription;// "cc transaction successfull";
            //cccVM.RequestId = resp.RequestId;//reset the requestid from the new transaction
            //cccVM.authResponse = resp;//get and set from upay auth service call



            //
            return retVal;
        }

    }
}