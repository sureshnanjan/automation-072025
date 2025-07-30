using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
    internal class TypeWithEvent
    {
        string name;
        int value;
        public event EventHandler<EventArgs> Event;
        public TypeWithEvent() { }

        public void FireEvent() { 
            this.Event.Invoke(this, EventArgs.Empty);
        }
    }
}
