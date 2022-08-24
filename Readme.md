<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128553200/16.1.9%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T352035)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Rich Text Editor for ASP.NET MVC - How to open and save documents from a database

This code example demonstrates how to open and save RichEdit documents from a database binary column.

## Implementation Details

### Open a document

* Pass a model with a binary property (rich text content to be displayed) to the RichEdit's PartialView.
* Call the [RichEditExtension.Open](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.RichEditExtension.Open.overloads) method to open a new document with the specified document ID and content type, and retrieve the binary content from the passed model:

```cs
@Html.DevExpress().RichEdit(settings => {
    settings.Name = "RichEditName";
    settings.CallbackRouteValues = new { Controller = "Home", Action = "RichEditPartial" };
    //...
}).Open(Model.DocumentId, Model.DocumentFormat, () => { return Model.Document; }).GetHtml()
```
### Save a document

* Click the Save ribbon command to initiate a save operation for the active document.
* Use the [RichEditSettings.Saving](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.RichEditSettings.Saving) property to save a document in a byte array.
* Call the [RichEditExtension.SaveCopy](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.RichEditExtension.SaveCopy.overloads) method to get the active document as a byte array, save it to the related bound model's binary property, and set the [Handled](https://docs.devexpress.com/AspNet/DevExpress.Web.Office.DocumentSavingEventArgs.Handled) property to `true` to prevent the [default document processing](https://docs.devexpress.com/AspNet/403545/components/rich-text-editor/document-management/save-a-document):

```cs
settings.Saving = (s, e) => {
    byte[] docBytes = RichEditExtension.SaveCopy("RichEditName", DevExpress.XtraRichEdit.DocumentFormat.Rtf);
    DXWebApplication1.Models.DataHelper.SaveDocument(docBytes);
    e.Handled = true;
};
```

## Files to Look At
<!-- default file list -->
- [RichEditPartial.cshtml](./CS/DXWebApplication1/Views/Home/RichEditPartial.cshtml) (VB: [RichEditPartial.vbhtml](./VB/DXWebApplication1/Views/Home/RichEditPartial.vbhtml))
- [DataHelper.cs](./CS/DXWebApplication1/Models/DataHelper.cs) (VB: [DataHelper.vb](./VB/DXWebApplication1/Models/DataHelper.vb))
<!-- default file list end -->

## Documentation
- [ASPxRichEdit Document Management](https://docs.devexpress.com/AspNet/401562/components/rich-text-editor/document-management)

## More Examples
- [Rich Text Editor for Web Forms - How to open and save documents from a database](https://github.com/DevExpress-Examples/aspxrichedit-how-to-save-and-load-documents-from-a-database-t352034)
