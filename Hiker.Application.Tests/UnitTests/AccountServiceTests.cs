using System;
using System.Threading.Tasks;
using FluentAssertions;
using Hiker.Application.Features.Authentication.DTO;
using Hiker.Application.Features.Authentication.Services;
using Hiker.Application.Features.Authentication.Services.Interfaces;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;
using Moq;
using NUnit.Framework;

namespace Hiker.Application.Tests.UnitTests
{
    [TestFixture]
    public class AccountServiceTests
    {
        private AccountService _sut;
        private Mock<IFacebookService> _facebookServiceMock;
        private Mock<IUserRepository> _userRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _facebookServiceMock = new Mock<IFacebookService>(MockBehavior.Strict);
            _userRepositoryMock = new Mock<IUserRepository>(MockBehavior.Strict);
            _sut = new AccountService(_facebookServiceMock.Object, _userRepositoryMock.Object);
        }

        [Test]
        public async Task RegisterUserFromFacebookAsync_WhenFacebookUserExists_ShouldAddUserToDatabase()
        {
            //Arrange
            var facebookToken = new FacebookToken { Token = "abc" };
            var facebookUser = new FacebookUser
            {
                FacebookId = "123", Birthdate = DateTime.Now, Email = "email", FirstName = "Jan", LastName = "Kowalski",
                Gender = "M"
            };
            var userId = Guid.NewGuid();
            _facebookServiceMock.Setup(x => x.GetUserFromFacebookAsync(facebookToken.Token)).ReturnsAsync(facebookUser);
            _userRepositoryMock.Setup(x => x.GetByFacebookIdAsync(facebookUser.FacebookId)).ReturnsAsync((User)null);
            _userRepositoryMock.Setup(x => x.AddAsync(It.IsAny<User>())).ReturnsAsync(userId);
            
            //Act
            var result = await _sut.RegisterUserFromFacebookAsync(facebookToken);

            //Assert
            result.Should().Be(userId);
        }
    }
}