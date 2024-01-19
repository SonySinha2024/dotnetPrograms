namespace EMS.Entities;

public class Department{
    public int Id{set; get;}
    public string Name{set; get;}
    public string Location{set; get;}

    public Department(){
        Console.WriteLine("Department const invoked.....");
    }
}