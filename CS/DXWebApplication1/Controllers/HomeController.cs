using System;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DevExpress.XtraRichEdit;
using DXWebApplication1.Models;

namespace DXWebApplication1.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult RichEditPartial() {
            var model = new RichEditData()
            {
                DocumentId = Guid.NewGuid().ToString(),
                DocumentFormat = DocumentFormat.Rtf,
                Document = DataHelper.GetDocument()
            };
            return PartialView(model);
        }
    }
}