namespace DataTriggerCorruptedExample.Database.Helpers
{    
    public class WeakEvent<TEventHandler> where TEventHandler : class
    {
        private readonly List<WeakReference<TEventHandler>> _handlers = new List<WeakReference<TEventHandler>>();

        public void AddHandler(TEventHandler handler)
        {
            RemoveDeadHandlers();
            _handlers.Add(new WeakReference<TEventHandler>(handler));
        }

        public void RemoveHandler(TEventHandler handler)
        {
            RemoveDeadHandlers();
            _handlers.RemoveAll(wr =>
            {
                if (wr.TryGetTarget(out var target))
                {
                    // Try to remove all references which are equal
                    return ReferenceEquals(target, handler);
                }
                return true;
            });
        }

        public void RaiseEvent(Action<TEventHandler> raiseAction)
        {
            RemoveDeadHandlers();
            foreach (var wr in _handlers)
            {
                if (wr.TryGetTarget(out var target))
                {
                    raiseAction(target);
                }
            }
        }

        private void RemoveDeadHandlers()
        {
            RemoveDuplicateHandlers();

            _handlers.RemoveAll(wr => !wr.TryGetTarget(out _));
        }

        private void RemoveDuplicateHandlers()
        {
            var uniqueHandlers = new HashSet<TEventHandler>();
            _handlers.RemoveAll(wr =>
            {
                if (wr.TryGetTarget(out var target))
                {
                    return !uniqueHandlers.Add(target);
                }
                return true;
            });
        }
    }
}