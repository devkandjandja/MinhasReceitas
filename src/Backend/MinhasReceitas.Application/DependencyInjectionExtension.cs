using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinhasReceitas.Application.Services.AutoMapper;
using MinhasReceitas.Application.Services.Cryptography;
using MinhasReceitas.Application.UserCases.User.Register;

namespace MinhasReceitas.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AddAutoMapper(services);
            AddUserCases(services);
            AddPasswordEncrypter(services,configuration);
        }
        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper());
        }
        private static void AddUserCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }

        private static void AddPasswordEncrypter(IServiceCollection services, IConfiguration configuration)
        {
            var additionalkey = configuration.GetValue<string>("Settings:Password:Additionalkey");

            services.AddScoped(option => new PasswordEncripter(additionalkey!));
        }
    }
} 
