﻿namespace ApartmentRentalSystem.Startup.Specs
{
    using ApartmentRentalSystem.Application.Identity.Commands.CreateUser;
    using ApartmentRentalSystem.Application.Identity.Commands.LoginUser;
    using FluentAssertions;
    using Infrastructure.Identity;
    using MyTested.AspNetCore.Mvc;
    using Web.Features;
    using Xunit;

    public class IdentityControllerSpecs
    {
        [Fact]
        public void RegisterShouldHaveCorrectAttributes()
            => MyController<IdentityController>
                .Calling(c => c
                    .Register(CreateUserCommandFakes.Data.GetCommand()))

                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Post)
                    .SpecifyingRoute(nameof(IdentityController.Register)));

        [Fact]
        public void LoginShouldHaveCorrectAttributes()
            => MyController<IdentityController>
                .Calling(c => c
                    .Login(new LoginUserCommand(With.No<string>(), With.No<string>())))

                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Post)
                    .SpecifyingRoute(nameof(IdentityController.Login)));

        [Theory]
        [InlineData(
            IdentityFakes.TestEmail, 
            IdentityFakes.ValidPassword, 
            JwtTokenGeneratorFakes.ValidToken)]
        public void LoginShouldReturnTokenWhenUserEntersValidCredentials(string email, string password, string token)
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                    .WithLocation("/Identity/Login")
                    .WithMethod(HttpMethod.Post)
                    .WithJsonBody(new 
                    {
                        Email = email,
                        Password = password
                    }))

                .To<IdentityController>(c => c
                    .Login(new LoginUserCommand(email, password)))

                .Which()
                .ShouldReturn()
                .ActionResult<LoginOutputModel>(result => result
                    .Passing(model => model.Token.Should().Be(token)));
    }
}
