<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/DXWebApplication1/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/DXWebApplication1/Controllers/HomeController.vb))
* [DataHelper.cs](./CS/DXWebApplication1/Models/DataHelper.cs) (VB: [DataHelper.vb](./VB/DXWebApplication1/Models/DataHelper.vb))
* [DataClassesDataContext.cs](./CS/DXWebApplication1/Models/EF/DataClassesDataContext.cs) (VB: [DataClassesDataContext.vb](./VB/DXWebApplication1/Models/EF/DataClassesDataContext.vb))
* [Doc.cs](./CS/DXWebApplication1/Models/EF/Doc.cs) (VB: [Doc.vb](./VB/DXWebApplication1/Models/EF/Doc.vb))
* [Index.cshtml](./CS/DXWebApplication1/Views/Home/Index.cshtml)
* [RichEditPartial.cshtml](./CS/DXWebApplication1/Views/Home/RichEditPartial.cshtml)
<!-- default file list end -->
# RichEdit - How to save and load documents from a database


This code example demonstrates how to save and restore RichEdit documents from a database using a binary column.<br><br>Load document

* Pass a model with a binary property (rich text content to be displayed) to the RichEdit's PartialView.
* Use the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcRichEditExtension_Opentopic">RichEditExtension.Open</a> method to open a new document with the specified/unique document ID and the necessary rich content type, and retrieve the binary content from the passed model (see the RichEditPartial source code file):<br><br>

```cs
@Html.DevExpress().RichEdit(settings => {
    settings.Name = "RichEditNameHere";
    settings.CallbackRouteValues = new { Controller = ..., Action = "ActionMethodThatHandlesRichEditCallbacks" };
}).Open(UNIQUE_DOCUMENT_ID_HERE, RICH_TEXT_FORMAT_HERE, () => { return MODEL_BINARY_PROPERTY_HERE; }).GetHtml()
```

<br>

```vb
@Html.DevExpress().RichEdit( _
    Sub(settings)
            settings.Name = "RichEditNameHere"
            settings.CallbackRouteValues = New With {.Controller = "...", .Action = "ActionMethodThatHandlesRichEditCallbacks"}
    End Sub).Open(UNIQUE_DOCUMENT_ID_HERE, RICH_TEXT_FORMAT_HERE, _
              Function()
                      Return MODEL_BINARY_PROPERTY_HERE
              End Function).GetHtml()
```

<br>Save a document

* Click the built-in toolbar's Save button/item.
* Use the <a href="https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.RichEditSettings.Saving">RichEditSettings.Saving</a> property to handle the <a href="https://documentation.devexpress.com/AspNet/DevExpressWebOfficeDocumentManager_AutoSavingtopic.aspx">DocumentManager.AutoSaving</a> event.
* Retrieve the modified content via the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcRichEditExtension_SaveCopytopic">RichEditExtension.SaveCopy</a> method, save it to the related bound model's binary property, and set the EventArgs Handled property to True (see the HomeController source code file):<br><br>

```cs
settings.Saving = (s, e) =>
{
    byte[] docBytes = RichEditExtension.SaveCopy("RichEditName", DevExpress.XtraRichEdit.DocumentFormat.Rtf);
    DXWebApplication1.Models.DataHelper.SaveDocument(docBytes);
    e.Handled = true;
};
```

<br>

```vb
settings.Saving = Sub(s, e)
    Dim docBytes As Byte() = RichEditExtension.SaveCopy("RichEditName", DevExpress.XtraRichEdit.DocumentFormat.Rtf)
    DXWebApplication1.Models.DataHelper.SaveDocument(docBytes)
    e.Handled = True
End Sub
```

<br><strong>See Also:</strong><br><strong>WebForms Version:</strong><br><a href="https://www.devexpress.com/Support/Center/p/T352034">T352034: ASPxRichEdit - How to save and load documents from a database</a>‌

<br/>


