using Microsoft.Extensions.DependencyInjection;
using WS.Business.Implementations;
using WS.Business.Interfaces;
using WS.DataAccess.Implementations.EF.Repositories;
using WS.DataAccess.Interfaces;

namespace WS.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services) 
        {

            // servis genelinde AutoMapper kullanabilir kılmış oluyorum aynı zamanda
            // AutoMapperın ihtiyaç duyduğu IMapper tipindeki objeyi IoC e register etmiş oluyoruz.
            services.AddAutoMapper(typeof(CustomerBs));


            // IoC REGISTATION
            //------------------------------------------------- 

            services.AddScoped <IBrandBs, BrandBs>();
            services.AddScoped <IBrandRepository, BrandRepository>();

            services.AddScoped <ICustomerBs, CustomerBs>();
            services.AddScoped <ICustomerRepository, CustomerRepository>();

            services.AddScoped <IEmployeeBs, EmployeeBs>();
            services.AddScoped <IEmployeeRepository, EmployeeRepository>();

            services.AddScoped <IFlightBs, FlightBs>();
            services.AddScoped <IFlightRepository, FlightRepository>();

            services.AddScoped <ISeatNumberBs, SeatNumberBs>();
            services.AddScoped <ISeatNumberRepository, SeatNumberRepository>();

            services.AddScoped <ITicketBs, TicketBs>();
            services.AddScoped <ITicketRepository, TicketRepository>();

            services.AddScoped<IAdminPanelUserBs, AdminPanelUserBs>();
            services.AddScoped<IAdminPanelUserRepository, AdminPanelUserRepository>();

            //------------------------------------------------- 

        }
    }
}
