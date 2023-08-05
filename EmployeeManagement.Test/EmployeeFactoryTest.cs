using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test
{
    public class EmployeeFactoryTest
    {
        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500()
        {
            //Arrange
            var employeeFactory = new EmployeeFactory();

            //Act
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Sam", "John");

            //Assert
            Assert.Equal(2500, employee.Salary);

        }
        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500()
        {
            //Arrange
            var employeeFactory = new EmployeeFactory();

            //Act
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Sam", "John");

            //Assert
            Assert.True( employee.Salary>=2500 && employee.Salary<=3500);

        }
        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_AlternativeWay()
        {
            //Arrange
            var employeeFactory = new EmployeeFactory();

            //Act
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Sam", "John");

            //Assert
            Assert.True(employee.Salary >= 2500);
            Assert.True(employee.Salary <= 3500);

        }
        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_AlternativeWayWithRange()
        {
            //Arrange
            var employeeFactory = new EmployeeFactory();

            //Act
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Sam", "John");

            //Assert
            Assert.InRange(employee.Salary,2500,3000);
        }
        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_PrecisionExample()
        {
            //Arrange
            var employeeFactory = new EmployeeFactory();

            //Act
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Sam", "John");
            employee.Salary = 2500.123m;

            //Assert
            Assert.Equal(2500,employee.Salary,0);
        }
        [Fact]
        public void CreateEmployee_IsExternalIsTrue_ReturnTypeMustBeExternalEmployee()
        {
            //Arrange
            var employeeFactory = new EmployeeFactory();

            //Act
            var employee = employeeFactory.CreateEmployee("Sam", "John", "Marvel", true);

            //Assert
            Assert.IsType<ExternalEmployee>(employee);
        }
    }
}
