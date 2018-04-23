Imports System
Imports System.Linq
Imports DevExpress.XtraRichEdit
Imports DXWebApplication1.Models.EF

Namespace DXWebApplication1.Models
	Public Class DataHelper
		Public Shared Function GetDocument() As Byte()
			Dim context As New DataClassesDataContext()
			Return context.Docs.FirstOrDefault().DocBytes.ToArray()
		End Function

		Public Shared Sub SaveDocument(ByVal bytes() As Byte)
			Dim context As New DataClassesDataContext()
			context.Docs.FirstOrDefault().DocBytes = bytes
			context.SaveChanges()
		End Sub
	End Class
	Public Class RichEditData
		Public Property DocumentId() As String
		Public Property DocumentFormat() As DocumentFormat
		Public Property Document() As Byte()
	End Class
End Namespace