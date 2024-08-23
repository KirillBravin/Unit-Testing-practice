using Calculator;
using UserAuthentication;

namespace UserAuthentication.Tests
{
    public class AuthenticationTests
    {
        [Fact]
        public void TestRegistration()
        {
            // Arrange
            IUserService userService = new UserService();
            string name = "John";
            string password = "123nohack";
            // Act
            userService.Register(name, password);
            // Assert
            bool loginResult = userService.Login(name, password);
            Assert.True(loginResult);
        }

        [Fact]
        public void TestRegistrationWithDublicateUsername()
        {
            //Arrange
            IUserService userService = new UserService();
            string name = "John";
            string password = "123nohack";
            //Act
            bool firstRegistration = userService.Register(name, password);
            bool dublicateRegistration = userService.Register(name, password);
            //Assert
            Assert.True(firstRegistration);
            Assert.False(dublicateRegistration);
        }

        [Fact]
        public void TestLoginWithWrongPassword()
        {
            //Arrange
            IUserService userService = new UserService();
            string name = "John";
            string correctPassword = "123nohack";
            string incorrectPassword = "321hack";
            //Act
            userService.Register(name, correctPassword);
            //Assert
            bool loginResult = userService.Login(name, incorrectPassword);
            Assert.False(loginResult);
        }

        [Fact]
        public void TestPasswordChange()
        {
            //Arrange
            IUserService userService = new UserService();
            string name = "John";
            string password = "123nohack";
            string newPassword = "84654861";
            //Act
            userService.Register(name, password);
            userService.ChangePassword(name, password, newPassword);
            //Assert
            var userWithOldPassword = userService.Login(name, password);
            var userWithNewPassword = userService.Login(name, newPassword);

            Assert.False(userWithOldPassword);
            Assert.True(userWithNewPassword);
        }
    }
}