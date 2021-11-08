using ArcadeScore.Domain.Core.Interfaces;
using ArcadeScore.Domain.Core.Notifications;
using ArcadeScore.Domain.Interfaces.Infra.Data;
using ArcadeScore.Domain.Interfaces.Infra.Data.Repositories;
using ArcadeScore.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ArcadeScore.Domain.Commads.Usuario
{
    public class UsuarioCommandHandler : CommandHandler, IRequestHandler<UsuarioCreateCommand>, IRequestHandler<UsuarioEditCommand>
    {
        private readonly IMediatorHandler _bus;
        private readonly IUsuarioRepository _repository;

        public UsuarioCommandHandler(IUsuarioRepository repository,
                IMediatorHandler bus,
                IUnitOfWork uow,
                INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _bus = bus;
            _repository = repository;
        }

        public async Task<Unit> Handle(UsuarioCreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                NotifyValidationErrors(request);
            else
            {

                UsuarioModel score = new UsuarioModel(Guid.NewGuid(), request.Nome, request.Sobrenome, request.Email, request.DataNascimento, request.Escolaridade);

                try
                {
                    _repository.Add(score);
                    await Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            return Unit.Value;
        }

        public async Task<Unit> Handle(UsuarioEditCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                NotifyValidationErrors(request);

            else
            {
                UsuarioModel score = await _repository.GetById(request.Id);
                score.SetDados(request.Nome, request.Sobrenome, request.Email, request.DataNascimento, request.Escolaridade);

                try
                {
                    _repository.Update(score);
                    await Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            return Unit.Value;
        }


    }
}
