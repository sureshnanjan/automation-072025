using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
    internal class EventEmitter
    {
        private readonly List<EventSubscriber> _subscribers;
        public EventEmitter()
        {
            _subscribers = new List<EventSubscriber>();
        }
        // Subscribe a EventSubscriber to an event
        public void Subscribe(EventSubscriber subscriber)
        {
            if (subscriber == null)
                throw new ArgumentNullException(nameof(subscriber));

            if (!_subscribers.Contains(subscriber))
            {
                _subscribers.Add(subscriber);
                Console.WriteLine($"Subscriber {subscriber.GetType().Name} subscribed ");
            }

        }
        public void Unsubscribe(EventSubscriber subscriber) { }
        public void PublishEvent(EventArgs eventArgs)
        {
            if (eventArgs == null)
                throw new ArgumentNullException(nameof(eventArgs));

            List<EventSubscriber> currentSubscribers;
            currentSubscribers = _subscribers.ToList(); // Create a copy to avoid issues with concurrent modifications
            
            Console.WriteLine($"Publishing to {currentSubscribers.Count} subscribers");

            foreach (var subscriber in currentSubscribers)
            {
                try
                {
                    subscriber.HandleEvent(eventArgs);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in subscriber {subscriber.GetType().Name}: {ex.Message}");
                    // In production, you might want to log this or handle it differently
                }
            }
        }
    }
}
