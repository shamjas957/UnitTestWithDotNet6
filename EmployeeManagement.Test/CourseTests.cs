using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test
{
    public class CourseTests
    {
        [Fact]
        public void CourseConstructor_ContructCourse_IsNewMustBeTrue()
        {
            //Arrange
            //nothing to arrange

            //Act
            var course = new Course("Test New Course");

            //Assert
            Assert.True(course.IsNew);
        }
    }
}
