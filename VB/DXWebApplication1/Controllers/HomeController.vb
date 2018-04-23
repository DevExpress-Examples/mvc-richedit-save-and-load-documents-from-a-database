Imports System
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports DevExpress.XtraRichEdit
Imports DXWebApplication1.Models

Namespace DXWebApplication1.Controllers
	Public Class HomeController
		Inherits Controller

		Public Function Index() As ActionResult

            Return View()
        End Function

        Public Function RichEditPartial() As ActionResult
            Dim model = New RichEditData() With {.DocumentId = Guid.NewGuid().ToString(), .DocumentFormat = DocumentFormat.Rtf, .Document = DataHelper.GetDocument()}
            Return PartialView(model)
        End Function
    End Class
End Namespace