using System.Collections.Generic;

namespace HastaneSistemi.Models //Güncellenecek.
{
    public class CustomQueue
    {
        private LinkedList<Hasta> queue = new LinkedList<Hasta>();

        public void Enqueue(Hasta hasta)
        {
            queue.AddLast(hasta);
        }

        public Hasta? Dequeue()
        {
            if (queue.Count == 0)
                return null;

            var hasta = queue.First.Value;
            queue.RemoveFirst();
            return hasta;
        }

        public bool IsEmpty()
        {
            return queue.Count == 0;
        }

        public List<Hasta> ToList()
        {
            return new List<Hasta>(queue);
        }
    }
}