@ModelType DXWebApplication1.Models.RichEditData

@Html.DevExpress().RichEdit( _
    Sub(settings)
        settings.Name = "RichEditName"
        settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "RichEditPartial"}
        settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
        settings.Saving = Sub(s, e)
                              Dim docBytes As Byte() = RichEditExtension.SaveCopy("RichEditName", DevExpress.XtraRichEdit.DocumentFormat.Rtf)
                              DXWebApplication1.Models.DataHelper.SaveDocument(docBytes)
                              e.Handled = True
                          End Sub
    End Sub).Open(Model.DocumentId, Model.DocumentFormat, _
              Function()
                  Return Model.Document
              End Function).GetHtml()