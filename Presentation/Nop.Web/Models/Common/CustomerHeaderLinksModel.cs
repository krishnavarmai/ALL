using Nop.Web.Framework.Models;
using Nop.Core.Domain.Common;
using System.Collections.Generic;

namespace Nop.Web.Models.Common
{
    public partial class CustomerHeaderLinksModel : BaseNopModel
    {
        public bool DisplayBillToLink { get; set; }
        public int CurrentBillToId { get; set; }
        public IList<BillTo> BillTos { get; set; }
    }
}