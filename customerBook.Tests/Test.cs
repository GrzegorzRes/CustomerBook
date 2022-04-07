using customerBook.App.Concrete;
using customerBook.App.Managers;
using customerBook.Domain.Entity;
using FluentAssertions;
using Moq;
using System.Linq;
using Xunit;

namespace customerBook.Tests
{
    public class Test
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            Customer customer = new Company("nameCompany", "12345678");
            CustomerService customerService = new CustomerService();
            int itemId = customerService.AddItem(customer);

            var manager = new CustomerManager(new MenuActionService(), new PersonManager(), new CompanyManager(), customerService, new CompanyService(), new PersonService());
            //Act

            Customer returnedCustomer = manager.GetCustomerById(itemId);
            //Assert

            returnedCustomer.Should().NotBeNull();
            returnedCustomer.Should().BeOfType(typeof(Company));
            returnedCustomer.Id.Should().Be(itemId);
            returnedCustomer.Should().Be(customer);

            //Clear

            customerService.RemoveItem(customer);
        }

        [Fact]
        public void Add_Company()
        {
            //Arrange
            Customer customer = new Company("nameCompany", "12345678");
            CustomerService customerService = new CustomerService();

            //Act
            int itmeId = customerService.AddItem(customer);
            int lastId = customerService.GetLastId();
            int isInList = customerService.ViewSelectedById(itmeId);

            //Assert
            isInList.Should().Be(1);
            customer.Id.Should().Be(lastId);

            //Clear
            customerService.RemoveItem(customer);
        }

        [Fact]
        public void Add_Person()
        {
            //Arrange
            Customer customer = new Person("firstName", "lastName");
            CustomerService customerService = new CustomerService();

            //Act
            int itmeId = customerService.AddItem(customer);
            int lastId = customerService.GetLastId();
            int isInList = customerService.ViewSelectedById(itmeId);

            //Assert
            isInList.Should().Be(1);
            customer.Id.Should().Be(lastId);

            //Clear
            customerService.RemoveItem(customer);
        }

        [Fact]
        public void ViewSelectedById_With_Correct_Id_Should_ReturnOne()
        {
            //Arrange
            Customer customer = new Company("nameCompany", "12345678");
            customer.Loc = new Location();
            CustomerService customerService = new CustomerService();
            int idItem = customerService.AddItem(customer);

            //Act
            var resoult = customerService.ViewSelectedById(idItem);

            //Assert
            resoult.Should().Be(1);

            //Clear
            customerService.RemoveItem(customer);
        }

        [Fact]
        public void ViewSelectedById_With_Incorrect_Id_Should_ReturnMinusOne()
        {
            //Arrange
            Customer customer = new Company("nameCompany", "12345678");
            customer.Loc = new Location();
            CustomerService customerService = new CustomerService();
            int idItem =  customerService.AddItem(customer);

            //Act
            var resoult = customerService.ViewSelectedById(2);

            //Assert
            resoult.Should().Be(-1);

            //Clear
            customerService.RemoveItem(customer);

        }

        [Fact]
        public void SelectFirstElementById_With_Correct_Id_Should_ReturnCompany()
        {
            //Arrange
            Customer customer = new Company("nameCompany", "12345678");
            CustomerService customerService = new CustomerService();
            int idItem = customerService.AddItem(customer);

            //Act
            var resoult = customerService.SelectFirstElementById(idItem);

            //Assert
            resoult.Should().NotBeNull();
            resoult.Should().BeOfType(typeof(Company));
            resoult.Should().BeSameAs(customer);

            //Clear
            customerService.RemoveItem(customer);

        }

        [Fact]
        public void SelectFirstElementById_With_Incorrect_Id_Should_ReturnNewCompany()
        {
            //Arrange
            Customer customer = new Company("nameCompany", "12345678");
            CustomerService customerService = new CustomerService();
            int idItem = customerService.AddItem(customer);

            Company newCompany = new Company();

            //Act
            var resoult = customerService.SelectFirstElementById(2);

            //Assert
            resoult.Should().NotBeNull();
            resoult.Should().BeOfType(typeof(Company));
            resoult.Id.Should().Be(0);

            //Clear
            customerService.RemoveItem(customer);
        }
        
        [Fact]
        public void DeleteCustomerById_With_Id_In_List_ReturnOne()
        {
            //Arrange
            Customer customer = new Company("nameCompany", "12345678");
            CustomerService customerService = new CustomerService();
            int idItem = customerService.AddItem(customer);

            Company newCompany = new Company();

            //Act
            var coutOnItem = customerService.Items.Count();
            var resoult = customerService.DeleteCustomerById(idItem);
            var item = customerService.SelectFirstElementById(idItem);

            //Assert
            item.Id.Should().NotBe(idItem);
            coutOnItem.Should().NotBe(customerService.Items.Count);
            resoult.Should().Be(1);

        }

        [Fact]
        public void DeleteCustomerById_With_Id_Not_In_List_ReturnOne()
        {
            //Arrange
            Customer customer = new Company("nameCompany", "12345678");
            CustomerService customerService = new CustomerService();
            int idItem = customerService.AddItem(customer);

            Company newCompany = new Company();

            //Act
            var coutOnItem = customerService.Items.Count();
            var resoult = customerService.DeleteCustomerById(4);
            var item = customerService.SelectFirstElementById(idItem);

            //Assert
            item.Id.Should().Be(idItem); 
            coutOnItem.Should().Be(customerService.Items.Count);
            resoult.Should().Be(1);

        }

    }
}