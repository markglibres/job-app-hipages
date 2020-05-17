using System.Collections.Generic;
using System.Linq;
using BizzPo.Core.Domain;
using Newtonsoft.Json;

namespace Leads.Domain.Entities.Seedwork
{
    public abstract class DbEntity : IDbEntity, IHasEvents
    {
        protected DbEntity()
        {
            Events = new List<IEvent>();
        }

        public int Id { get; private set; }
        public IList<IEvent> Events { get; }

        public void ClearEvents()
        {
            Events.Clear();
        }

        protected void Emit(IEvent @event)
        {
            if (Events.Any(e => e.Id == @event.Id)) return;

            Events.Add(@event);
        }
    }
}