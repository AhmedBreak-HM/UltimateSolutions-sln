using AutoMapper;
using UltimateSolutions.Application.Commands.Invoice;
using UltimateSolutions.Application.Commands.User.LogInUser;
using UltimateSolutions.Application.Commands.User.SignUpUser;
using UltimateSolutions.Application.Queries.Customer.GetAllCustomers;
using UltimateSolutions.Application.Queries.Product.GetAllProducts;
using UltimateSolutions.Application.Queries.User.GetUserByName;
using UltimateSolutions.Domain.Models;

namespace UltimateSolutions.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserApplication, UserForReturnDto>();
            CreateMap<UserApplication, LogInUserForReturnDto>();
            CreateMap<SignUpUserCommand, UserApplication>();
            CreateMap<Customer, CustomerForReturnDto>();
            CreateMap<Product, ProductForReturnDto>();
            CreateMap<CreateInvoiceCommand, InvoiceMaster>();
        }
    }
}