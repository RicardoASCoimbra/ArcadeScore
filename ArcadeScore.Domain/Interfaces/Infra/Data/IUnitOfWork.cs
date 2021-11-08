using System.Threading.Tasks;

namespace ArcadeScore.Domain.Interfaces.Infra.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        //Task Commit();
        void Close();
        string GetContextId();
    }
}
