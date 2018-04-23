using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using DevExpress.Mvvm;
using DXSample.Data;

namespace DXSample.ViewModels {
    public class MainViewModel : ViewModelBase {

        public Employee SelectedEmployee {
            get { return GetProperty(() => SelectedEmployee); }
            set { SetProperty(() => SelectedEmployee, value); }
        }
        public ObservableCollection<EmployeeDepartment> Departments {
            get { return GetProperty(() => Departments); }
            set { SetProperty(() => Departments, value); }
        }

        public MainViewModel() {
            var departments = DataHelper.GetEmployees()
                .GroupBy(x => x.GroupName)
                .Select(x => CreateEmployeeDepartment(x.Key, x.Take(10).ToArray()))
                .ToArray();
            Departments = new ObservableCollection<EmployeeDepartment>(departments);
            SelectedEmployee = Departments[0].Employees[0];
        }

        EmployeeDepartment CreateEmployeeDepartment(string name, IList<Employee> employees) {
            var image = DataHelper.GetEmployeeDepartmentImage(name);
            return new EmployeeDepartment(name, image, employees);
        }
    }

    public class Employee {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string StateProvinceName { get; set; }
        public string PostalCode { get; set; }
        public string CountryRegionName { get; set; }
        public string GroupName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Title { get; set; }
        public byte[] ImageData { get; set; }
        public ImageSource Image { get { return Gender == "F" ? DataHelper.ImageFemale : DataHelper.ImageMale; } }
        public override string ToString() {
            return FirstName + " " + LastName;
        }
    }
    public class EmployeeDepartment {
        public string Name { get; set; }
        public object Image { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }

        public EmployeeDepartment(string name, object image, IList<Employee> employees) {
            this.Name = name;
            this.Image = image;
            this.Employees = new ObservableCollection<Employee>(employees);
        }

        public override string ToString() {
            return Name;
        }
    }
}