namespace AutoFixtureDemo.API.Models;

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? Age { get; set; } = null;
    public decimal Salary { get; set; }

    public Employee(string firstName, string lastName, int age, decimal salary)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Salary = salary;
    }

    public string GetFullName() => $"{FirstName} {LastName}";
}