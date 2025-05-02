namespace HospitalSystem.Models //Güncellenecek.
{
    public class CPQueue
    {
        private List<Patient> heap = new List<Patient>();
        private int Parent(int i) => (i - 1) / 2;
        private int Left(int i) => 2 * i + 1;
        private int Right(int i) => 2 * i + 2;

        public void Enqueue(Patient patient)
        {
            heap.Add(patient);
            int i = heap.Count - 1;

            // Sift Up işlemi
            while (i != 0 && heap[Parent(i)].Priority > heap[i].Priority)
            {
                Swap(i, Parent(i));
                i = Parent(i);
            }
        }

        public Patient? Dequeue()
        {
            if (heap.Count == 0)
                return null;

            if (heap.Count == 1)
            {
                var root = heap[0];
                heap.RemoveAt(0);
                return root;
            }

            Patient rootHasta = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            Heapify(0);

            return rootHasta;
        }

        private void Heapify(int i)
        {
            int smallest = i;
            int left = Left(i);
            int right = Right(i);

            if (left < heap.Count && heap[left].Priority < heap[smallest].Priority)
                smallest = left;

            if (right < heap.Count && heap[right].Priority < heap[smallest].Priority)
                smallest = right;

            if (smallest != i)
            {
                Swap(i, smallest);
                Heapify(smallest);
            }
        }

        private void Swap(int i, int j)
        {
            var temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        public bool IsEmpty()
        {
            return heap.Count == 0;
        }

        public List<Patient> ToList()
        {
            return new List<Patient>(heap);
        }
    }
}