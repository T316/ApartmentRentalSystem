namespace ApartmentRentalSystem.Application.Statistics.Queries.Current
{
    using AutoMapper;
    using Common.Mapping;
    using Domain.Statistics.Models;

    public class GetCurrentStatisticsOutputModel : IMapFrom<Statistics>
    {
        public int TotalApartmentAds { get; private set; }

        public int TotalApartmentAdViews { get; private set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<Statistics, GetCurrentStatisticsOutputModel>()
                .ForMember(cs => cs.TotalApartmentAds, cfg => cfg
                    .MapFrom(s => s.ApartmentAdViews.Count));
    }
}
