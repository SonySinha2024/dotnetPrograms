using EMS.Entities;
using MySql.Data.MySqlClient;

namespace EMS.Repositories;

public class MySqlDBManager{
    public MySqlDBManager(){}

    public List<Employee> GetAll(){
        List<Employee> employees = new List<Employee>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString=@"server=localhost; port=3306; user=root; password=root123; database=dotnet";
        MySqlCommand cmd =  new MySqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "Select * from employees";
        try{
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read()){
                int id = int.Parse(reader["id"].ToString());
                string? firstName = reader["firstName"].ToString();
                string? lastName = reader["lastName"].ToString();
                string? address = reader["address"].ToString();
                string? email = reader["email"].ToString();
                Employee emp = new Employee();
                emp.Id = id;
                emp.FirstName = firstName;
                emp.LastName = lastName;
                emp.Email = email;
                emp.Address = address;
                employees.Add(emp);
            }

        }catch(Exception e){
            Console.WriteLine(e.Message);
        }finally{
            con.Close();
        }
        return employees;
    }

    public Employee GetById(int id){
        Employee emp = new Employee();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString=@"server=localhost; port=3306; user=root; password=root123; database=dotnet";
        MySqlCommand cmd =  new MySqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "Select * from employees where id="+id;
        try{
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read()){
                int pid = int.Parse(reader["id"].ToString());
                string? firstName = reader["firstName"].ToString();
                string? lastName = reader["lastName"].ToString();
                string? address = reader["address"].ToString();
                string? email = reader["email"].ToString();
                
                emp.Id = pid;
                emp.FirstName = firstName;
                emp.LastName = lastName;
                emp.Email = email;
                emp.Address = address;
                
            }

        }catch(Exception e){
            Console.WriteLine(e.Message);
        }finally{
            con.Close();
        }
        return emp;
    }

    public string DeleteEmployeeById(int id){
        string msg = "Employee not deleted";
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString=@"server=localhost; port=3306; user=root; password=root123; database=dotnet;";
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "Delete from employees where id="+id;
        try{
            con.Open();
            cmd.ExecuteNonQuery();
            msg = "Employee deleted";

        }catch(Exception e){

        }finally{
            con.Close();
        }
        return msg;
    }
    public string UpdateEmployeeDetails(Employee emp){
        string msg = "Details not updated";
       MySqlConnection con=new MySqlConnection();
        con.ConnectionString=@"server=localhost; port=3306; user=root; password=root123; database=dotnet";
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText="UPDATE employees SET firstName='"+emp.FirstName+"',lastName='"+emp.LastName+"',email='"+emp.Email+"',address='"+emp.Address+"' WHERE id="+ emp.Id;
        try{
            con.Open();
             cmd.ExecuteNonQuery();
             msg="details updataed";
             
        }
        catch(Exception e){
            
        }
        finally{
            con.Close();
        }
        return msg;
    }

    public string InsertEmployee(Employee emp){
        Console.WriteLine("in insert employee repository");
        Console.WriteLine(emp.FirstName);
        string msg = "not inserted";
        
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=@"server=localhost; port=3306; user=root; password=root123; database=dotnet";
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText="INSERT into employees (firstName,lastName,address,email) values('"+emp.FirstName+"','"+emp.LastName+"','"+emp.Address+"','"+emp.Email+"')";

        try{
            con.Open();
            cmd.ExecuteNonQuery();
            msg = "details inserted";
           
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            con.Close();
        }
        return msg;
    }
}