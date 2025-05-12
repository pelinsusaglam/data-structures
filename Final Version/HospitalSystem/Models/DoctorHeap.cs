namespace HospitalSystem.Models
{
    public class DoctorHeap
    {
        private List<Doctor> heap = new List<Doctor>();
        private Dictionary<string, int> nameIndexMap = new Dictionary<string, int>(); // Doktor ismi -> index

        public int Count => heap.Count;

        // Doktor ekleme
        public void Add(Doctor doctor)
        {
            heap.Add(doctor);
            int index = heap.Count - 1;
            nameIndexMap[doctor.Name] = index;
            HeapifyUp(index);
        }

        public Doctor Remove() // En az hastaya bakan doktoru çıkarır
        {
            Doctor minDoctor = heap[0];
            nameIndexMap.Remove(minDoctor.Name);

            heap[0] = heap[heap.Count - 1];
            nameIndexMap[heap[0].Name] = 0;

            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);

            return minDoctor;
        }

        public Doctor AssignPatient() // Hasta ataması yapar ve en az hastaya bakan doktora 1 hasta ekler
        {
            Doctor leastBusyDoctor = heap[0];
            leastBusyDoctor.PatientCount++;

            HeapifyDown(0); // root değiştiği için heapifydown yeterli

            Console.WriteLine($"Assigned a patient to Dr. {leastBusyDoctor.Name}. Total patients: {leastBusyDoctor.PatientCount}");
            return leastBusyDoctor;
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (heap[index].PatientCount >= heap[parent].PatientCount) break;

                Swap(index, parent);
                index = parent;
            }
        }

        private void HeapifyDown(int index)
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

        private void Swap(int i, int j) // Doktor pozisyonlarını değiştirir.
        {
            var temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;

            // Update dictionary
            nameIndexMap[heap[i].Name] = i;
            nameIndexMap[heap[j].Name] = j;
        }

        public void Print()
        {
            foreach (var doctor in heap)
            {
                Console.WriteLine($"Dr. {doctor.Name}: {doctor.PatientCount} patients");
            }
        }

        public void UpdateDoctorCount(string name, int delta)
        {
            if (!nameIndexMap.TryGetValue(name, out int index)) return;

            heap[index].PatientCount += delta;
            HeapifyUp(index);
            HeapifyDown(index);
        }
    }
}
