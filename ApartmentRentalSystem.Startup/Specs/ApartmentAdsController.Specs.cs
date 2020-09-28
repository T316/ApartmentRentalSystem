namespace ApartmentRentalSystem.Startup.Specs
{
    using System.Linq;

    using Application.Features.ApartmentAds.Queries.Search;
    using Domain.Models.ApartmentAds;
    using FakeItEasy;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using Web.Features;
    using Xunit;

    public class ApartmentAdsControllerSpecs
    {
        [Fact]
        public void GetShouldHaveCorrectAttributes()
            => MyController<ApartmentAdController>
                .Calling(c => c.Get(With.Default<SearchApartmentAdsQuery>()))

                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Get));

        [Theory]
        [InlineData(2)]
        public void GetShouldReturnAllApartmentAdsWithoutAQuery(int totalApartmentAds)
            => MyPipeline
                .Configuration()
                .ShouldMap("/ApartmentAds")

                .To<ApartmentAdController>(c => c.Get(With.Empty<SearchApartmentAdsQuery>()))
                .Which(instance => instance
                    .WithData(A.CollectionOfDummy<ApartmentAd>(totalApartmentAds)))

                .ShouldReturn()
                .ActionResult<SearchApartmentAdsOutputModel>(result => result
                    .Passing(model => model
                        .ApartmentAds.Count().Should().Be(totalApartmentAds)));

        [Fact]
        public void GetShouldReturnAvailableApartmentAdsWithoutAQuery()
            => MyPipeline
                .Configuration()
                .ShouldMap("/ApartmentAds")

                .To<ApartmentAdController>(c => c.Get(With.Empty<SearchApartmentAdsQuery>()))
                .Which(instance => instance
                    .WithData(ApartmentAdFakes.Data.GetApartmentAds()))

                .ShouldReturn()
                .ActionResult<SearchApartmentAdsOutputModel>(result => result
                    .Passing(model => model
                        .ApartmentAds.Count().Should().Be(10)));

        [Theory]
        [InlineData("Neighborhood10")]
        public void GetShouldReturnFilteredApartmentAdsWithQuery(string neighborhood)
            => MyPipeline
                .Configuration()
                .ShouldMap($"/ApartmentAds?{nameof(neighborhood)}={neighborhood}")

                .To<ApartmentAdController>(c => c.Get(new SearchApartmentAdsQuery { Neighborhood = neighborhood }))
                .Which(instance => instance
                    .WithData(ApartmentAdFakes.Data.GetApartmentAds()))

                .ShouldReturn()
                .ActionResult<SearchApartmentAdsOutputModel>(result => result
                    .Passing(model =>
                    {
                        model.ApartmentAds.Count().Should().Be(1);
                        model.ApartmentAds.First().Neighborhood.Should().Be(neighborhood);
                    }));
    }
}
