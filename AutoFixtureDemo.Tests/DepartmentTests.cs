using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using AutoFixtureDemo.API.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Internal;

namespace AutoFixtureDemo.Tests;

public class DepartmentTests
{
    public DepartmentTests()
    {
        // _fixture = new Fixture()
        //     .Customize(new AutoMoqCustomization()
        //     {
        //         ConfigureMembers = true
        //     });
    }
}