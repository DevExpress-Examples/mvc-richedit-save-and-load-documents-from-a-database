Imports System.Data.Entity
Imports System

Namespace DXWebApplication1.Models.EF

	Partial Public Class DataClassesDataContext
		Inherits DbContext

		Public Sub New()
			MyBase.New("name=DocumentsConnectionString")
		End Sub

		Public Overridable Property Docs() As DbSet(Of Doc)
	End Class
End Namespace
