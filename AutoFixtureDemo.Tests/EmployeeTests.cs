using AutoFixture;
using AutoFixture.Xunit2;
using AutoFixtureDemo.API.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Internal;

namespace AutoFixtureDemo.Tests;

public class EmployeeTests
{
    [Fact]
    public void WhenConstructorIsInvoked_ThenValidInstanceIsReturned()
    {
        // Arrange
        Fixture _fixture = new();

        var firstName = _fixture.Create<string>();
        var lastName = _fixture.Create<string>();
        var age = _fixture.Create<int>();
        var salary = _fixture.Create<decimal>();

        // Act
        var employee = new Employee(firstName, lastName, age, salary);

        // Assert
        employee.FirstName.Should().Be(firstName);
        employee.LastName.Should().Be(lastName);
        employee.Age.Should().Be(age);
        employee.Salary.Should().Be(salary);
    }

    [Fact]
    public void WhenAddEmployeeIsInvoked_ThenEmployeeIsAddedToTheList1()
    {
        // Arrange
        Fixture _fixture = new();

        var employee = _fixture.Create<Employee>();
        var department = _fixture.Create<Department>();
        var employeesCount = department.Employees.Count;

        // Act
        department.AddEmployee(employee);

        // Assert
        department.Employees.Count.Should().Be(employeesCount + 1);
    }


    [Fact]
    public void WhenAddEmployeeIsInvoked_ThenEmployeeIsAddedToTheList2()
    {
        // Arrange
        Fixture _fixture = new();

        var employee = _fixture.Create<Employee>();

        var employees = _fixture.CreateMany<Employee>(5).ToList();

        var department = _fixture
                .Build<Department>()
                .With(x => x.Employees, employees)
                .Create();

        // Act
        department.AddEmployee(employee);

        // Assert
        department.Employees.Count.Should().Be(6);
    }

    [Fact]
    public void WhenAddEmployeeIsInvoked_ThenEmployeeIsAddedToTheList3()
    {
        // Arrange
        Fixture _fixture = new();

        var employee = _fixture
            .Build<Employee>()
            .OmitAutoProperties()
            .Create();

        var employees = _fixture
            .Build<Employee>()
            .OmitAutoProperties()
            .CreateMany(5)
            .ToList();

        var department = _fixture
            .Build<Department>()
            .With(x => x.Employees, employees)
            .Create();

        // Act
        department.AddEmployee(employee);

        // Assert
        department.Employees.Count.Should().Be(6);
    }

    [Theory, AutoData]
    public void GivenEmployeeExists_WhenGetEmployeeIsInvoked_ThenEmployeeIsReturned(
        string firstName, string lastName)
    {
        // Arrange
        Fixture _fixture = new();

        var employees = _fixture.Build<Employee>()
            .OmitAutoProperties()
            .With(x => x.FirstName, firstName)
            .With(x => x.LastName, lastName)
            .CreateMany(1)
            .ToList();

        var department = _fixture.Build<Department>()
            .With(x => x.Employees, employees)
            .Create();

        // Act
        var employee = department.GetEmployee(firstName);

        // Assert 
        employee.Should().NotBeNull();
        employee!.LastName.Should().Be(lastName);
        // employee!.Age.Should().BeNull();
    }
}