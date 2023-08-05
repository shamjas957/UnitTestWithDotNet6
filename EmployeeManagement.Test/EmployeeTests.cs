using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test
{
    public class EmployeeTests
    {
        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameIsConcatenated()
        {
            //Arrange
            var employee = new InternalEmployee("John", "Samuel", 0, 2500, false, 1);

            //Act
            employee.FirstName = "Ram";
            employee.LastName = "Mohan";

            //Assert
            Assert.Equal("Ram Mohan", employee.FullName,ignoreCase:true);
        }
        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameStartsWithFirstName()
        {
            //Arrange
            var employee = new InternalEmployee("John", "Samuel", 0, 2500, false, 1);

            //Act
            employee.FirstName = "Ram";
            employee.LastName = "Mohan";

            //Assert
            Assert.StartsWith(employee.FirstName, employee.FullName);
        }
        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameEndsWithLastName()
        {
            //Arrange
            var employee = new InternalEmployee("John", "Samuel", 0, 2500, false, 1);

            //Act
            employee.FirstName = "Ram";
            employee.LastName = "Mohan";

            //Assert
            Assert.EndsWith(employee.LastName, employee.FullName);
        }
        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameContainsPartOfConcatenation()
        {
            //Arrange
            var employee = new InternalEmployee("John", "Samuel", 0, 2500, false, 1);

            //Act
            employee.FirstName = "Ram";
            employee.LastName = "Mohan";

            //Assert
            Assert.Contains("am Mo", employee.FullName);
        }
        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameSoundsLikeConcatenation()
        {
            //Arrange
            var employee = new InternalEmployee("John", "Samuel", 0, 2500, false, 1);

            //Act
            employee.FirstName = "Ram";
            employee.LastName = "Mohan";

            //Assert
            Assert.Matches("R(a|e|i)m Moha(n|t)", employee.FullName);
        }
    }
}
