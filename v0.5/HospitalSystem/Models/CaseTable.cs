using HospitalSystem.Models;

namespace HospitalSystem.CaseRepository
{
    public static class CaseTable
    {
        private static int capacity = 5;
        public static CaseAVLTree[] Table = new CaseAVLTree[capacity];
        private static int Hash(int caseno){
            return caseno % 5; //Beş bölüm olacak vaka numaralı ona göre eklenecek.
        }
        public static void AddHash(Case? pcase){
            int index = Hash(pcase.CaseNo);
            if(Table[index]==null){
                Table[index] = new CaseAVLTree();
            }
            Table[index].Add(pcase.CaseNo,pcase.Name,pcase.Speciality);
            Console.WriteLine($"Hastalık eklendi : {pcase.CaseNo} - {pcase.Name} - {pcase.Speciality} - {index}");
        }
        public static Case? FindHash(int caseno){
            int index = Hash(caseno);
            if(Table[index] == null) return null;
            return Table[index].Find(caseno);
        }
    }
}