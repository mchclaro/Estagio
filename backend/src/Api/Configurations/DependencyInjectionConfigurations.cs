using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using backend.src.Application.Aggregates.User.Mappings;
using Data.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infrastructure.FileService;
using MediatR;

namespace Api.Configurations
{
    public static class DependencyInjectionConfigurations
    {
        public static IServiceCollection ConfigureServicesDI(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {

            // AutoMapper
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

            // Register repositories
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IAppointmentPaymentRepository, AppointmentPaymentRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IEstimateRepository, EstimateRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IReportsRepository, ReportsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddTransient<IFileStorageService, LocalStorageService>();
            services.AddTransient<IFileStorageServiceS3, CloudStorageService>();

            services.AddScoped<Mediator>();

            return services;
        }
    }
}