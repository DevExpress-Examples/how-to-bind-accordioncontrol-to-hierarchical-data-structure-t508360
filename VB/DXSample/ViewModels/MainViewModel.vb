Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Windows.Media
Imports DevExpress.Mvvm
Imports DXSample.Data

Namespace DXSample.ViewModels
    Public Class MainViewModel
        Inherits ViewModelBase

        Public Property SelectedEmployee() As Employee
            Get
                Return GetProperty(Function() SelectedEmployee)
            End Get
            Set(ByVal value As Employee)
                SetProperty(Function() SelectedEmployee, value)
            End Set
        End Property
        Public Property Departments() As ObservableCollection(Of EmployeeDepartment)
            Get
                Return GetProperty(Function() Departments)
            End Get
            Set(ByVal value As ObservableCollection(Of EmployeeDepartment))
                SetProperty(Function() Departments, value)
            End Set
        End Property

        Public Sub New()

            Dim departments_Renamed = DataHelper.GetEmployees().GroupBy(Function(x) x.GroupName).Select(Function(x) CreateEmployeeDepartment(x.Key, x.Take(10).ToArray())).ToArray()
            Departments = New ObservableCollection(Of EmployeeDepartment)(departments_Renamed)
            SelectedEmployee = Departments(0).Employees(0)
        End Sub

        Private Function CreateEmployeeDepartment(ByVal name As String, ByVal employees As IList(Of Employee)) As EmployeeDepartment
            Dim image = DataHelper.GetEmployeeDepartmentImage(name)
            Return New EmployeeDepartment(name, image, employees)
        End Function
    End Class

    Public Class Employee
        Public Property Id() As Integer
        Public Property ParentId() As Integer
        Public Property FirstName() As String
        Public Property MiddleName() As String
        Public Property LastName() As String
        Public Property JobTitle() As String
        Public Property Phone() As String
        Public Property EmailAddress() As String
        Public Property AddressLine1() As String
        Public Property City() As String
        Public Property StateProvinceName() As String
        Public Property PostalCode() As String
        Public Property CountryRegionName() As String
        Public Property GroupName() As String
        Public Property BirthDate() As Date
        Public Property HireDate() As Date
        Public Property Gender() As String
        Public Property MaritalStatus() As String
        Public Property Title() As String
        Public Property ImageData() As Byte()
        Public ReadOnly Property Image() As ImageSource
            Get
                Return If(Gender = "F", DataHelper.ImageFemale, DataHelper.ImageMale)
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return FirstName & " " & LastName
        End Function
    End Class
    Public Class EmployeeDepartment
        Public Property Name() As String
        Public Property Image() As Object
        Public Property Employees() As ObservableCollection(Of Employee)

        Public Sub New(ByVal name As String, ByVal image As Object, ByVal employees As IList(Of Employee))
            Me.Name = name
            Me.Image = image
            Me.Employees = New ObservableCollection(Of Employee)(employees)
        End Sub

        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class
End Namespace