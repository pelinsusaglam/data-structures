using HospitalSystem.CaseRepository;

namespace HospitalSystem.Models{
    public static class CaseRepository{
        public static void Main(string[] args)
        {
            Case? case_1 = new Case(100,"Kalp Krizi","Kardiyoloji");
            Case? case_2 = new Case(105,"Hiper tansiyon","Kardiyoloji");
            Case? case_3 = new Case(110, "Anjina Pektoris", "Kardiyoloji");
            Case? case_4 = new Case(115, "Kalp Yetmezliği", "Kardiyoloji");
            Case? case_5 = new Case(120, "Bradiaritmi", "Kardiyoloji");
            Case? case_6 = new Case(125, "Takikardi", "Kardiyoloji");
            Case? case_7 = new Case(130, "Endokardit", "Kardiyoloji");
            Case? case_8 = new Case(101, "Anemi", "Dahiliye");
            Case? case_9 = new Case(106, "Gastrit", "Dahiliye");
            Case? case_10 = new Case(111, "Diyabet", "Dahiliye");
            Case? case_11 = new Case(116, "Hipotiroidi", "Dahiliye");
            Case? case_12 = new Case(121, "Astım", "Dahiliye");
            Case? case_13 = new Case(126, "Peptik Ülser", "Dahiliye");
            Case? case_14 = new Case(131, "Romatoid Artrit", "Dahiliye");
            Case? case_15 = new Case(136, "Hepatit B", "Dahiliye");
            Case? case_16 = new Case(141, "Kronik Bronşit", "Dahiliye");
            Case? case_17 = new Case(146, "Pankreatit", "Dahiliye");
            Case? case_18 = new Case(102, "Apandisit", "Genel Cerrahi");
            Case? case_19 = new Case(107, "Safra Kesesi Taşı", "Genel Cerrahi");
            Case? case_20 = new Case(112, "Fıtık", "Genel Cerrahi");
            Case? case_21 = new Case(117, "Hemoroid", "Genel Cerrahi");
            Case? case_22 = new Case(122, "Meme Kisti", "Genel Cerrahi");
            Case? case_23 = new Case(127, "Varikosel", "Genel Cerrahi");
            Case? case_24 = new Case(132, "Tiroid Nodülü", "Genel Cerrahi");
            Case? case_25 = new Case(137, "Pilonoidal Sinüs", "Genel Cerrahi");
            Case? case_26 = new Case(142, "İnguinal Fıtık", "Genel Cerrahi");
            Case? case_27 = new Case(147, "Perianal Abse", "Genel Cerrahi");
            CaseTable.AddHash(case_1);
            CaseTable.AddHash(case_2);
            CaseTable.AddHash(case_3);
            CaseTable.AddHash(case_4);
            CaseTable.AddHash(case_5);
            CaseTable.AddHash(case_6);
            CaseTable.AddHash(case_7);
            CaseTable.AddHash(case_8);
            CaseTable.AddHash(case_9);
            CaseTable.AddHash(case_10);
            CaseTable.AddHash(case_11);
            CaseTable.AddHash(case_12);
            CaseTable.AddHash(case_13);
            CaseTable.AddHash(case_14);
            CaseTable.AddHash(case_15);
            CaseTable.AddHash(case_16);
            CaseTable.AddHash(case_17);
            CaseTable.AddHash(case_18);
            CaseTable.AddHash(case_19);
            CaseTable.AddHash(case_20);
            CaseTable.AddHash(case_21);
            CaseTable.AddHash(case_22);
            CaseTable.AddHash(case_23);
            CaseTable.AddHash(case_24);
            CaseTable.AddHash(case_25);
            CaseTable.AddHash(case_26);
            CaseTable.AddHash(case_27);
        }
        public static Case? FindCase(int caseno){
            return CaseTable.FindHash(caseno);
        }
    }
}