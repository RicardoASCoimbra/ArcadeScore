using ArcadeScore.Domain.Interfaces.Infra.Data.Repositories;
using ArcadeScore.Domain.Models;
using ArcadeScore.Infra.Data.Configuration;
using ArcadeScore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeScore.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<UsuarioModel>, IUsuarioRepository
    {
        public UsuarioRepository(ArcadeScoreDB context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UsuarioModel>> GetAll()
        {
            IQueryable<UsuarioModel> query = DbSet.Where(x => x.Excluido);

            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<UsuarioModel> GetById(Guid id)
        {
            IQueryable<UsuarioModel> query = DbSet.Where(x => x.Id.Equals(id));
            return await query.AsNoTracking().SingleOrDefaultAsync();
        }
    }
}
