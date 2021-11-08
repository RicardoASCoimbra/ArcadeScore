using ArcadeScore.Domain.Interfaces.Domain;
using ArcadeScore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArcadeScore.Domain.Interfaces.Infra.Data.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<UsuarioModel>
    {
        Task<IEnumerable<UsuarioModel>> GetAll();
        Task<UsuarioModel> GetById(Guid id);
    }
}
