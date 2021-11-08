using ArcadeScore.Domain.Core.Events;
using ArcadeScore.Domain.Core.Interfaces;
using Newtonsoft.Json;

namespace ArcadeScore.Infra.Data.EventSourcing
{
    public class EventStore : IEventStore
    {
        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(theEvent, serializedData, "_user.Name");
        }
    }
}
