using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeJson;
using System.Collections.Generic;

namespace EmployeeJson.ArgsParsing;

[TestClass]
public class JsonControllerTests
{
    List<EmployeeModel> testList_ExpectedList = new()
    {
        new EmployeeModel() { Id = 3, FirstName = "Jerry", LastName = "Beans", SalaryPerHour = 33.54m },
        new EmployeeModel() { Id = 5, FirstName = "Tom", LastName = "Smith", SalaryPerHour = 68.04m },
        new EmployeeModel() { Id = 4, FirstName = "Laira", LastName = "Tooth", SalaryPerHour = 63.64m },
        new EmployeeModel() { Id = 1, FirstName = "Jerry", LastName = "Beans", SalaryPerHour = 45m },
    };
    List<EmployeeModel> testList_SameIds = new()
    {
        new EmployeeModel() { Id = 3, FirstName = "Tom", LastName = "Smith", SalaryPerHour = 33.54m },
        new EmployeeModel() { Id = 3, FirstName = "Laira", LastName = "Tooth", SalaryPerHour = 68.04m },
        new EmployeeModel() { Id = 4, FirstName = "Jerry", LastName = "Beans", SalaryPerHour = 63.64m },
        new EmployeeModel() { Id = 1, FirstName = "Maria", LastName = "Browns", SalaryPerHour = 45m },
    };
    List<EmployeeModel> testList_NoId = new()
    {
        new EmployeeModel() { Id = 3, FirstName = "Tom", LastName = "Smith", SalaryPerHour = 33.54m },
        new EmployeeModel() { Id = 5, FirstName = "Laira", LastName = "Tooth", SalaryPerHour = 68.04m },
        new EmployeeModel() { Id = 4, FirstName = "Jerry", LastName = "Beans", SalaryPerHour = 63.64m },
        new EmployeeModel() { Id = 1, FirstName = "Maria", LastName = "Browns", SalaryPerHour = 45m },
    };
    List<EmployeeModel> testList_Empty = new();

    [TestMethod]
    public void IdExists_ExpectedList_ReturnFalse()
    {
        var result = JsonController.IdExists(testList_ExpectedList, 4);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IdExists_SameIds_ReturnFalse()
    {
        var result = JsonController.IdExists(testList_SameIds, 3);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IdExists_NoId_ReturnFalse()
    {
        var result = JsonController.IdExists(testList_NoId, 2);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IdExists_Empty_ReturnFalse()
    {
        var result = JsonController.IdExists(testList_Empty, 2);
        Assert.IsFalse(result);
    }





}