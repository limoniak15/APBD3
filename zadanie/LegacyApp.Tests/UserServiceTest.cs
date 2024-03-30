using System;
using JetBrains.Annotations;
using LegacyApp;
using Xunit;

namespace LegacyApp.Tests;

[TestSubject(typeof(UserService))]
public class UserServiceTest
{
    //1
    [Fact]
    public void AddUser_Should_Return_False_When_FirtsName_Is_Missing()
    {
        // Arrange - przygotowanie zależności do testu
        var userService = new UserService();
        // Act - wywołanie testowanej zależności
        var addResult = userService.AddUser("", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        // Assert - sprawdzenie wyniku
        Assert.False(addResult);
    }
    //2
    [Fact]
    public void AddUser_Should_Return_False_When_LastName_Is_Missing()
    {
        // Arrange - przygotowanie zależności do testu
        var userService = new UserService();
        // Act - wywołanie testowanej zależności
        var addResult = userService.AddUser("John", "", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        // Assert - sprawdzenie wyniku
        Assert.False(addResult);
    }
    //3
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Is_Incorrect()
    {
        // Arrange - przygotowanie zależności do testu
        var userService = new UserService();
        // Act - wywołanie testowanej zależności
        var addResult = userService.AddUser("John", "Doe", "udajeEmail", DateTime.Parse("1982-03-21"), 1);
        // Assert - sprawdzenie wyniku
        Assert.False(addResult);
    }
    //4
    [Fact]
    public void AddUser_Should_Throw_ArgumentExeption_When_Client_Doesnt_Exist()
    {
        // Arrange - przygotowanie zależności do testu
        var userService = new UserService();
        // Act & Assert - wywołanie testowanej zależności i sprawdzenei wyników
        Assert.Throws<ArgumentException>(() =>
        {
            userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 0);
        });
    }
    //5
    [Fact]
    public void AddUser_Should_Return_False_When_Age_Lower_Than_21()
    {
        // Arrange 
        var userService = new UserService();
        // Act 
        var addResult = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("2010-03-21"), 1);
        // Assert 
        Assert.False(addResult);
    }
    
}