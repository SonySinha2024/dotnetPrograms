namespace EMS.Entities;

public class Employee{
    public Employee(){
        Console.WriteLine("Employee const invoked......");
    }


    public int Id{set; get;}
    public string FirstName{set; get;}
    public string LastName{set; get;}
    public string Address{set; get;}
    public string Email{set; get;}

    public Employee(string FirstName,string LastName,string Address, string Email){
        this.FirstName=FirstName;
        this.LastName=LastName;
        this.Email=Email;
        this.Address=Address;
    }

    public Employee(int Id,string FirstName,string LastName,string Address, string Email){
        this.Id=Id;
        this.FirstName=FirstName;
        this.LastName=LastName;
        this.Email=Email;
        this.Address=Address;
    }
}