using EMS.Entities;
using EMS.Repositories;
using EMS.Services;


public class EmployeeService : IEmployeeService{
    public List<Employee> GetAll(){
        List<Employee> employees=new List<Employee>();
        MySqlDBManager mgr=new MySqlDBManager();
        employees=mgr.GetAll();
        return employees;
    }
    public Employee GetById(int id){
        MySqlDBManager mgr=new MySqlDBManager();
        Employee emp=mgr.GetById(id);
        Console.WriteLine("fetching employee using DBMangager");
        return emp;
    }

    public void Delete(int id){
        MySqlDBManager mgr=new MySqlDBManager();
        string msg = mgr.DeleteEmployeeById(id);
        Console.WriteLine(msg);
    }

    public void Update(Employee emp){
        MySqlDBManager mgr=new MySqlDBManager();
        string msg = mgr.UpdateEmployeeDetails(emp);
        Console.WriteLine(msg);
    }

    public void Insert(Employee emp){
        Console.WriteLine("in insert of service");
        MySqlDBManager mgr = new MySqlDBManager();
        string msg = mgr.InsertEmployee(emp);
        Console.WriteLine(msg);
    }
}