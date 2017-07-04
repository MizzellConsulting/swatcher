using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveLantern.Swatcher
{
    internal struct EventNotification
    {
        public readonly FileSystemItemEvent Event;
        public readonly string Name;

        public EventNotification(FileSystemItemEvent @event, string name)
        {
            Event = @event;
            Name = name;
        }
    }
}
