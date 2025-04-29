namespace HastaneSistemi.Models
{
    public class Hasta
    {
        public long TCno { get; set; }
        public string AdSoyad { get; set; }
        public string VakaNo { get; set; }
        public string Durum { get; set; }
        public int Priority { get; set; }
        public bool IsHospitalized { get; set; } = false;
        public Hasta? Forward { get; set; }
        public Hasta() { }
        public Hasta(long tcno, string adSoyad, string vakaNo, string durum, int priority, bool isHospitalized)
        {
            TCno = tcno;
            AdSoyad = adSoyad;
            VakaNo = vakaNo;
            Durum = durum;
            Priority = priority;
            IsHospitalized = isHospitalized;
            Forward = null;
        }
    }
}
