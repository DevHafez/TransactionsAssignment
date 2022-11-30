using AutoMapper;
using TransactionsAssignment.Domain.Entities;
using TransactionsAssignment.Infrastructure.ViewModel;

namespace TransactionsAssignment.Infrastructure.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerModel, Customer>()
                .ForMember(dest => dest.Id,
                        opt => opt.MapFrom(src => src.CustomerId))
                .ReverseMap();
        }
    }
}
