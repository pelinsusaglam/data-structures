namespace HospitalSystem.Models
{
    public class DoctorHeap
    {
        private List<Doctor> heap = new List<Doctor>();

        public int Count => heap.Count;

        // Doktor ekleme
        public void Add(Doctor doctor)
        {
            heap.Add(doctor);
            HeapifyUp(heap.Count - 1);
        }

        public Doctor Remove() // En az hastaya bakan doktoru çıkarır
        {
            Doctor minDoctor = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);
            return minDoctor;
        }


        public Doctor AssignPatient() // Hasta ataması yapar ve en az hastaya bakan doktora 1 hasta ekler
        {
            Doctor leastBusyDoctor = heap[0];
            leastBusyDoctor.PatientCount++;

            HeapifyDown(0); // root değişti heapifydown yeterli

            Console.WriteLine($"Assigned a patient to Dr. {leastBusyDoctor.Name}. Total patients: {leastBusyDoctor.PatientCount}");
            return leastBusyDoctor;
        }
        private void HeapifyUp(int index) // Heap içinde yukarı doğru düzenleme
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (heap[index].PatientCount >= heap[parent].PatientCount) break;

                Swap(index, parent);
                index = parent;
            }
        }
        private void HeapifyDown(int index) // Heap içinde aşağı doğru düzenleme
        {
            int last = heap.Count - 1;
            while (true)
            {
                int left = 2 * index + 1;
                int right = 2 * index + 2;
                int smallest = index;

                if (left <= last && heap[left].PatientCount < heap[smallest].PatientCount)
                    smallest = left;
                if (right <= last && heap[right].PatientCount < heap[smallest].PatientCount)
                    smallest = right;

                if (smallest == index) break;

                Swap(index, smallest);
                index = smallest;
            }
        }
        private void Swap(int i, int j) // İki doktoru yer değiştir
        {
            var temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
        public void Print()// Heapteki tüm doktorları yazdır
        {
            foreach (var doctor in heap)
            {
                Console.WriteLine($"Dr. {doctor.Name}: {doctor.PatientCount} patients");
            }
        }
        public void UpdateDoctorCount(string name, int delta)
        {
            int index = heap.FindIndex(d => d.Name == name);
            if (index == -1) return;

            heap[index].PatientCount += delta;

            HeapifyUp(index);
            HeapifyDown(index);
        }
    }
}