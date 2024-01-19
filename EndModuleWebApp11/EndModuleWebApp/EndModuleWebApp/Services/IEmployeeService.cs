using EMS.Entities;
namespace EMS.Services;

public interface IEmployeeService{
    public List<Employee> GetAll();
    public Employee GetById(int id);
    public void Delete(int id);

    public void Update(Employee emp);
    public void Insert(Employee emp);
}