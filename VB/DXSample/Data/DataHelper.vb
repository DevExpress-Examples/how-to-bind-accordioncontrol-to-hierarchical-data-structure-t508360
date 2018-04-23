Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Windows.Media
Imports System.Xml.Serialization
Imports DevExpress.Utils
Imports DevExpress.Xpf.Core.Native
Imports DXSample.ViewModels

Namespace DXSample.Data


    <XmlRoot("Employees")> _
    Public Class DataHelper
        Inherits List(Of Employee)

        Private Shared ReadOnly EmployeeDepartmentImages As New List(Of String)() From {"administration", "inventory", "manufacturing", "quality", "research", "sales"}
        Private Shared imageFemaleSrc As ImageSource
        Private Shared imageMaleSrc As ImageSource

        Private Shared Serializer As New XmlSerializer(GetType(DataHelper))

        Public Shared Function GetDataStream() As Stream
            Return AssemblyHelper.GetResourceStream(GetType(DataHelper).Assembly, "Data/EmployeesWithPhoto.xml", True)
        End Function
        Public Shared Function GetEmployeeDepartmentImage(ByVal departmentName As String) As Object
            Dim imageName = EmployeeDepartmentImages.FirstOrDefault(Function(x) departmentName.ToLower().Contains(x))
            If String.IsNullOrEmpty(imageName) Then
                Return Nothing
            End If
            Return "/DXSample;component/Images/" & imageName & ".png"
        End Function

        Public Shared Function GetEmployees() As List(Of Employee)
            Return DirectCast(Serializer.Deserialize(GetDataStream()), List(Of Employee))
        End Function

        Public Shared ReadOnly Property ImageFemale() As ImageSource
            Get
                If imageFemaleSrc Is Nothing Then
                    imageFemaleSrc = ImageSourceHelper.GetImageSource(AssemblyHelper.GetResourceUri(GetType(DataHelper).Assembly, "Images/Person_Female.png"))
                End If
                Return imageFemaleSrc
            End Get
        End Property

        Public Shared ReadOnly Property ImageMale() As ImageSource
            Get
                If imageMaleSrc Is Nothing Then
                    imageMaleSrc = ImageSourceHelper.GetImageSource(AssemblyHelper.GetResourceUri(GetType(DataHelper).Assembly, "Images/Person_Male.png"))
                End If
                Return imageMaleSrc
            End Get
        End Property
    End Class
End Namespace
