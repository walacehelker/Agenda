using Implementation.Cadastro;
using Microsoft.Extensions.DependencyInjection;
using Services.Cadastro;

namespace InjectionDependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<ITipoAtendimentoService, TipoAtendimentoService>();
            services.AddScoped<IAtendimentoService, AtendimentoService>();
            services.AddScoped<IAtendimentoCadService, AtendimentoCadService>();

            return services;
        }
    }
}
