using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EndModuleWebApp.Models;
using EMS.Services;
using EMS.Entities;
using EMS.Repositories;
using EndModuleWebApp.Controllers;


public class EmployeesController : Controller{

    private readonly IEmployeeService _scv;

    public EmployeesController(IEmployeeService svc){
        Console.WriteLine("Employee Controller Constructor is being Invoked.....");
        this._scv=svc;
    }

    [HttpGet]
    public IActionResult Index(){
        Console.WriteLine("Employee Index Action Method is called...");
        List<Employee> employees = _scv.GetAll();
        TempData["allEmployees"] = employees;
        return View();
    }

    public IActionResult List(){
        Console.WriteLine("Employee List Action Method is called...");
        List<Employee> employees= _scv.GetAll();
        return View(employees);
    }

    [HttpGet]
    public IActionResult Details(int id){
        Console.WriteLine("Employee Details Action Method is called...");
        Employee emp = _scv.GetById(id);
        return View(emp);
    }

    [HttpGet]
    public IActionResult Delete(int id){
        Console.WriteLine("Employee Delete Action Method is called...");
        _scv.Delete(id);
        return View();
    }

    [HttpGet]
    public IActionResult Edit(int id){
        Console.WriteLine("Employee Edit Get Action Method is called...");
        List<Employee> employees= _scv.GetAll();
        var e= employees.Find((emp)=>emp.Id==id);  
        return View(e);
    }

    [HttpPost]
    public IActionResult Edit(IFormCollection form){
        Console.WriteLine("Employee Edit Post Action Method is called...");
        int id = int.Parse(form["Id"]);
        string fName = form["FirstName"];
        string lName = form["LastName"];
        string address = form["Address"];
        string email = form["Email"];
        Employee emp = new Employee(id,fName,lName,address,email);
        _scv.Update(emp);
        Console.WriteLine(emp.Id+ " " + emp.LastName);
        return RedirectToAction("Index","Employees",null);
    }

    [HttpGet]
    public IActionResult Insert(){
        return View();
    }

    public IActionResult Insert(IFormCollection form){
        Employee emp = new Employee{Id=int.Parse(form["Id"]),FirstName=form["FirstName"],LastName=form["LastName"],Address=form["Address"],Email=form["Email"]};
        Console.WriteLine(emp.FirstName);
        _scv.Insert(emp);
        return View();
    }
}