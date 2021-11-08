using ArcadeScore.Application.AppServices;
using ArcadeScore.Application.Interfaces;
using ArcadeScore.Domain.Commads.Usuario;
using ArcadeScore.Domain.Core.Interfaces;
using ArcadeScore.Domain.Core.Notifications;
using ArcadeScore.Domain.Interfaces.Infra.Data;
using ArcadeScore.Domain.Interfaces.Infra.Data.Repositories;
using ArcadeScore.Infra.Bus;
using ArcadeScore.Infra.Data.Configuration;
using ArcadeScore.Infra.Data.Context;
using ArcadeScore.Infra.Data.EventSourcing;
using ArcadeScore.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ArcadeScore.Infra.Ioc
{
    public  class NativeInjector
    {
        public static void RegisterAppServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStore, EventStore>();
            services.AddDbContext<ArcadeScoreDB>();
            services.AddScoped<ArcadeScoreDB>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            //--------------------------------------------------------------------------------------------------------------------------
            ///ArcadeScore
            //--------------------------------------------------------------------------------------------------------------------------
            //(Repositorio)
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            //(Application)
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            //(Command)
            services.AddScoped<IRequestHandler<UsuarioCreateCommand, Unit>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<UsuarioEditCommand, Unit>, UsuarioCommandHandler>();

        }
    }
}
