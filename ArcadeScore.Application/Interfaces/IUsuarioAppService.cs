using ArcadeScore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArcadeScore.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        Task Create(UsuarioViewModel model);
        Task Update(UsuarioViewModel model);
        Task<object> GetById(Guid id);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<UsuarioViewModel>> GetAll();
    }
}
