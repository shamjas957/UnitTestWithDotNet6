using EmployeeManagement.Business;
using EmployeeManagement.Business.EventArguments;
using EmployeeManagement.Business.Exceptions;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Services.Test;

namespace EmployeeManagement.Test
{
    public class EmployeeServiceTests
    {
        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreates_MustHaveAttendedFirstObligatoryCourse_WithObject()
        {
            //Arrange
            var employeeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            var employeeSerice = new EmployeeService(employeeManagementTestDataRepository, new EmployeeFactory());
            var obligatoryCourse = employeeManagementTestDataRepository.GetCourse(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

            //Act
            var internalEmployee = employeeSerice.CreateInternalEmployee("Sam", "John");

            //Assert
            Assert.Contains(obligatoryCourse, internalEmployee.AttendedCourses);
        }
        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreates_MustHaveAttendedFirstObligatoryCourse_WithPredicate()
        {
            //Arrange
            var employeeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            var employeeSerice = new EmployeeService(employeeManagementTestDataRepository, new EmployeeFactory());

            //Act
            var internalEmployee = employeeSerice.CreateInternalEmployee("Sam", "John");

            //Assert
            Assert.Contains(internalEmployee.AttendedCourses,course=>course.Id== Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));
        }
        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreates_MustHaveAttendedObligatoryCourse_AttendedCourseMustMatchWithObligatoryCourses()
        {
            //Arrange
            var employeeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            var employeeSerice = new EmployeeService(employeeManagementTestDataRepository, new EmployeeFactory());
            var obligatoryCourses = employeeManagementTestDataRepository.GetCourses(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"), Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

            //Act
            var internalEmployee = employeeSerice.CreateInternalEmployee("Sam", "John");

            //Assert
            Assert.Equal(obligatoryCourses, internalEmployee.AttendedCourses);
        }
        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreates_MustHaveAttendedObligatoryCourse_AttendedCourseMustNotBeNew()
        {
            //Arrange
            var employeeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            var employeeSerice = new EmployeeService(employeeManagementTestDataRepository, new EmployeeFactory());

            //Act
            var internalEmployee = employeeSerice.CreateInternalEmployee("Sam", "John");

            //Assert
            //foreach(var course in internalEmployee.AttendedCourses)
            //{
            //    Assert.False(course.IsNew);
            //}
            Assert.All(internalEmployee.AttendedCourses, course => Assert.False(course.IsNew));
        }
        [Fact]
        public async Task CreateInternalEmployeeAsync_InternalEmployeeCreates_MustHaveAttendedObligatoryCourse_AttendedCourseMustMatchWithObligatoryCourses()
        {
            //Arrange
            var employeeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            var employeeSerice = new EmployeeService(employeeManagementTestDataRepository, new EmployeeFactory());
            var obligatoryCourses = await employeeManagementTestDataRepository.GetCoursesAsync(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"), Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

            //Act
            var internalEmployee = await employeeSerice.CreateInternalEmployeeAsync("Sam", "John");

            //Assert
            Assert.Equal(obligatoryCourses, internalEmployee.AttendedCourses);
        }

        [Fact]
        public async Task GiveRaise_RaiseBelowMinimumGive_MustThrowInvaildRaiseException()
        {
            //Arrange
            var employeeSerice = new EmployeeService(new EmployeeManagementTestDataRepository(), new EmployeeFactory());
            var internalEmployee = new InternalEmployee("Sam", "John", 5, 3000, false, 1);

            //Act & Assert
            await Assert.ThrowsAsync<EmployeeInvalidRaiseException>(
               async () => await employeeSerice.GiveRaiseAsync(internalEmployee, 50));
        }
        [Fact]
        public void NotifyOfAbsence_EmployeeIsAbsent_OnEmployeeIsAbsentMustBeTriggered()
        {
            //Arrange
            var employeeSerice = new EmployeeService(new EmployeeManagementTestDataRepository(), new EmployeeFactory());
            var internalEmployee = new InternalEmployee("Sam", "John", 5, 3000, false, 1);

            //Act & Assert
            Assert.Raises<EmployeeIsAbsentEventArgs>(
                handler => employeeSerice.EmployeeIsAbsent += handler,
                handler => employeeSerice.EmployeeIsAbsent -= handler,
                () => employeeSerice.NotifyOfAbsence(internalEmployee));
        }
    }
}
