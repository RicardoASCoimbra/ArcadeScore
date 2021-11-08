using ArcadeScore.Domain.Core.Events;

namespace ArcadeScore.Domain.Core.Interfaces
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
