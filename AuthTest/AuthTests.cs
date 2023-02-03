using FluentAssertions;
using MauiApp1.Entities;
using MauiApp1.Enums;
using MauiApp1.Repositories.Interfaces;
using MauiApp1.Services;
using MauiApp1.Services.Interfaces;
using Moq;
using SharedComponents.Model.Request;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class AuthTests
    {
        [Fact]
        public async void ShouldLogin()
        {
            Mock<ITokenRepository> tokenRepoMock = new Mock<ITokenRepository>();
            Mock<IUserRepository> userRepoMock = new Mock<IUserRepository>();

            userRepoMock.Setup(x => x.Get()).Returns(new List<User>()
            {
                new User(){
                    Id = 1,
                    Email = "test@test.com",
                    FirstName = "test",
                    LastName = "test",
                    PermissionLevel = UserPermissionLevel.admin,
                    Synced = true
                }
            });

            tokenRepoMock.Setup(x => x.Get()).Returns(new List<Token>()
            {
                new Token(){
                    Id = 1,
                    UserId = 1,
                    Synced = true,
                    AuthToken = "testToken",
                    RefreshToken = "testRefreshToken",
                    TokenExpiry = DateTime.Now.AddHours(1)
                }
            });

            var authService = InstantiateAuthService(tokenRepoMock.Object, userRepoMock.Object);

            var result = await authService.Login(new LoginRequestModel());

            result.User.Id.Should().Be(result.Token.UserId);
        }

        private IAuthService InstantiateAuthService(ITokenRepository tokenRepo, IUserRepository userRepo) 
        {
            return new AuthService(tokenRepo, userRepo);
        }
    }
}