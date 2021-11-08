using ArcadeScore.Application.Interfaces;
using ArcadeScore.Application.ViewModels;
using ArcadeScore.Domain.Commads.Usuario;
using ArcadeScore.Domain.Core.Interfaces;
using ArcadeScore.Domain.Core.Notifications;
using ArcadeScore.Domain.Interfaces.Infra.Data.Repositories;
using ArcadeScore.Domain.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeScore.Application.AppServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly IHttpContextAccessor _httpContext;
        private readonly DomainNotificationHandler _notifications;
        private readonly IUsuarioRepository _repository;

        public UsuarioAppService(
            IMediatorHandler bus,
            IMapper mapper,
            INotificationHandler<DomainNotification> notifications,
            IUsuarioRepository repository,
            IHttpContextAccessor httpContext)
        {
            _bus = bus;
            _mapper = mapper;
            _notifications = (DomainNotificationHandler)notifications;
            _repository = repository;
            _httpContext = httpContext;
        }

        public async Task Create(UsuarioViewModel score)
        {
            UsuarioCreateCommand command = _mapper.Map<UsuarioCreateCommand>(score);
            await _bus.SendCommand(command);
        }

        public async Task Update(UsuarioViewModel score)
        {
            UsuarioEditCommand command = _mapper.Map<UsuarioEditCommand>(score);
            await _bus.SendCommand(command);
        }

        public async Task<object> GetById(Guid id)
        {
            var score = (await _repository.GetById(id));
            return _mapper.Map<UsuarioModel>(score);
        }

        public async Task<IEnumerable<UsuarioViewModel>> GetAll()
        {
            var scores = (await _repository.GetAll());
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(scores);
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await _repository.GetById(id);
            if (user != null)
            {
              try
                {
                    await DeleteFisica(user);
                }
                catch (Exception e)
                {
                    Console.WriteLine("MESSAGE: " + e.Message + "\n INNER: " + e.InnerException);
                    return false;
                }

                return true;
            }

            return false;

        }
        private async Task DeleteFisica(UsuarioModel user)
        {
            _repository.Delete(user);
            await _repository.SaveChangesAsync();
        }
    }
}
