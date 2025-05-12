namespace HospitalSystem.Models 
{
    public class CPQueue
    {
        private Patient[] heap;
        private int heapSize;
        private int Parent(int i) => (i - 1) / 2;
        private int Left(int i) => 2 * i + 1;
        private int Right(int i) => 2 * i + 2;

        public CPQueue()
        {
            heap = new Patient[16];
            heapSize = 0;
        }

        public void Enqueue(Patient patient)
        {
            // Dizi boyutu kontrolü
            if (heapSize == heap.Length)
            {
                ExpandArray();
            }

            // Hastayı dizinin sonuna ekle
            heap[heapSize] = patient;
            int i = heapSize;
            heapSize++;

            // Sift Up işlemi
            while (i != 0 && heap[Parent(i)].Priority > heap[i].Priority)
            {
                Swap(i, Parent(i));
                i = Parent(i);
            }
        }

        public Patient? Dequeue()
        {
            if (heapSize == 0)
                return null;

            if (heapSize == 1)
            {
                heapSize--;
                return heap[0];
            }

            Patient rootHasta = heap[0];
            heap[0] = heap[heapSize - 1];
            heapSize--;

            Heapify(0);

            return rootHasta;
        }

        private void Heapify(int i)
        {
            int smallest = i;
            int left = Left(i);
            int right = Right(i);

            if (left < heapSize && heap[left].Priority < heap[smallest].Priority)
                smallest = left;

            if (right < heapSize && heap[right].Priority < heap[smallest].Priority)
                smallest = right;

            if (smallest != i)
            {
                Swap(i, smallest);
                Heapify(smallest);
            }
        }

        private void ExpandArray()
        {
            Patient[] newArray = new Patient[heap.Length * 2];
            for (int i = 0; i < heapSize; i++)
            {
                newArray[i] = heap[i];
            }
            heap = newArray;
        }

        private void Swap(int i, int j)
        {
            var temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        public bool IsEmpty()
        {
            return heapSize == 0;
        }
    }
}