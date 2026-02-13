<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128640180/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T508360)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF Accordion Control - Bind to Hierarchical Data Structure

This example binds our WPF [Accordion Control](https://docs.devexpress.com/WPF/118347/controls-and-libraries/navigation-controls/accordion-control) to a hierarchical data structure. 

## Implementation Details

To display hierarchical data within the DevExpress WPF [Accordion Control](https://docs.devexpress.com/WPF/118347/controls-and-libraries/navigation-controls/accordion-control), bind the `ItemsSource` property to a collection populated with child items. Use the [ChildrenPath](https://docs.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionControl.ChildrenPath) property to specify collection name. 

In this example, the [Accordion Control](https://docs.devexpress.com/WPF/118347/controls-and-libraries/navigation-controls/accordion-control) is bound to a collection of "departments". Each department contains a collection of employees: 

```xaml
<dxa:AccordionControl
    ItemsSource="{Binding Departments}"
    ChildrenPath="Employees"
    SelectedItem="{Binding SelectedEmployee, Mode=TwoWay}"
    SelectionUnit="SubItem" />
```

`MainViewModel` exposes two bindable properties:

`Departments` – a collection of `EmployeeDepartment` objects grouped by department names.

`SelectedEmployee` – the employee selected in the [Accordion Control](https://docs.devexpress.com/WPF/118347/controls-and-libraries/navigation-controls/accordion-control).

At runtime, the view model loads employee data, groups it by department, and assigns the first available employee to the `SelectedEmployee` property:

```csharp
var departments = DataHelper.GetEmployees()
    .GroupBy(x => x.GroupName)
    .Select(x => CreateEmployeeDepartment(x.Key, x.Take(10).ToArray()))
    .ToArray();

Departments = new ObservableCollection<EmployeeDepartment>(departments);
SelectedEmployee = Departments[0].Employees[0];
```

Each `EmployeeDepartment` object includes an `Employees` collection:


```csharp
public class EmployeeDepartment {
    public string Name { get; set; }
    public ObservableCollection<Employee> Employees { get; set; }
}
```

## Files to Review

* [MainViewModel.cs](./CS/DXSample/ViewModels/MainViewModel.cs) (VB: [MainViewModel.vb](./VB/DXSample/ViewModels/MainViewModel.vb))
* [MainView.xaml](./CS/DXSample/Views/MainView.xaml) (VB: [MainView.xaml](./VB/DXSample/Views/MainView.xaml))

## Documentation

- [Accordion Control](https://docs.devexpress.com/WPF/118347/controls-and-libraries/navigation-controls/accordion-control)
- [AccordionItem](https://docs.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionItem)
- [AccordionViewMode](https://docs.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionViewMode)
- [MVVM Framework](https://docs.devexpress.com/WPF/15112/mvvm-framework)

## More Examples

- [WPF MVVM Framework - Use View Models Generated at Compile Time](https://github.com/DevExpress-Examples/wpf-mvvm-framework-view-model-generator)
- [WPF Dock Layout Manager - Bind the View Model Collection with LayoutAdapters](https://github.com/DevExpress-Examples/wpf-docklayoutmanager-bind-view-model-collection-with-layoutadapters)
- [WPF Dock Layout Manager - Bind the View Model Collection with IMVVMDockingProperties](https://github.com/DevExpress-Examples/wpf-docklayoutmanager-bind-view-model-collection-with-IMVVMDockingProperties)
- [WPF Dock Layout Manager - Populate a DockLayoutManager LayoutGroup with the ViewModels Collection](https://github.com/DevExpress-Examples/wpf-docklayoutmanager-display-viewmodels-collection-in-layoutgroup)
- [Add the Loading Decorator to the Application with the MVVM Structure](https://github.com/DevExpress-Examples/wpf-display-loading-decorator-in-manual-mode-with-mvvm)
- [WPF Hamburger Menu Control - Navigate Between the MVVM Views](https://github.com/DevExpress-Examples/wpf-hamburger-menu-with-mvvm)
- [Reporting for WPF - How to Use ViewModel Data as Report Parameters in a WPF MVVM Application](https://github.com/DevExpress-Examples/reporting-wpf-mvvm-viewmodel-data-to-report)
- [Reporting for WPF - How to Use the DocumentPreviewControl in a WPF MVVM Application to Preview a Report](https://github.com/DevExpress-Examples/reporting-wpf-mvvm-show-report-document-preview)

<!-- feedback -->
## Does This Example Address Your Development Requirements/Objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-accordion-bind-to-hierarchical-data-structure&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-accordion-bind-to-hierarchical-data-structure&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
