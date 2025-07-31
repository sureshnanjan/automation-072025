using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber;

internal class EventSubscriber
{
    private string handler_type;

    public EventSubscriber(string type_of_handler)
    {
        handler_type = type_of_handler;
    }
    public void HandleEvent(EventArgs eargs)
    {
        Console.WriteLine($"{handler_type.ToUpper()} handled the event with {eargs}");
    }
}