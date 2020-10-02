namespace ApartmentRentalSystem.Startup.Specs
{
    using System.Linq;

    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;
    using ApartmentRentalSystem.Domain.Rental.Models.Brokers;
    using Application.Features.ApartmentAds.Queries.Search;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using Web.Features;
    using Xunit;

    public class ApartmentAdsControllerSpecs
    {
        [Fact]
        public void GetShouldHaveCorrectAttributes()
            => MyController<ApartmentAdsController>
                .Calling(c => c.Search(With.Default<SearchApartmentAdsQuery>()))

                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Get));

        [Theory]
        [InlineData(2)]
        public void SearchShouldReturnAllApartmentAdsWithoutAQuery(int totalApartmentAds)
            => MyPipeline
                .Configuration()
                .ShouldMap("/ApartmentAds")

                .To<ApartmentAdsController>(c => c.Search(With.Empty<SearchApartmentAdsQuery>()))
                .Which(instance => instance
                    .WithData(BrokerFakes.Data.GetBroker(totalApartmentAds: totalApartmentAds)))

                .ShouldReturn()
                .ActionResult<SearchApartmentAdsOutputModel>(result => result
                    .Passing(model => model
                        .ApartmentAds.Count().Should().Be(totalApartmentAds)));

        [Fact]
        public void GetShouldReturnAvailableApartmentAdsWithoutAQuery()
            => MyPipeline
                .Configuration()
                .ShouldMap("/ApartmentAds")

                .To<ApartmentAdsController>(c => c.Search(With.Empty<SearchApartmentAdsQuery>()))
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

                .To<ApartmentAdsController>(c => c.Search(new SearchApartmentAdsQuery { Neighborhood = neighborhood }))
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
