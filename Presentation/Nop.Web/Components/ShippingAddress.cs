using Microsoft.AspNetCore.Mvc;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Web.Components
{
    public class ShippingAddressViewComponent : NopViewComponent
    {
        private readonly ICommonModelFactory _commonModelFactory;

        public ShippingAddressViewComponent(ICommonModelFactory commonModelFactory)
        {
            this._commonModelFactory = commonModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _commonModelFactory.PrepareShippingAddressModel();
            return View(model);
        }
    }
}
