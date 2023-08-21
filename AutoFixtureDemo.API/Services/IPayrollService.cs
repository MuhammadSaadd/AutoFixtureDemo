using AutoFixtureDemo.API.Models;

namespace AutoFixtureDemo.API.Services;

public interface IPayrollService
{
    void PaySalaries(IEnumerable<Employee> employee);
}