using ArcadeScore.Domain.Core.Commands;
using ArcadeScore.Domain.Core.Events;
using System.Threading.Tasks;

namespace ArcadeScore.Domain.Core.Interfaces
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
