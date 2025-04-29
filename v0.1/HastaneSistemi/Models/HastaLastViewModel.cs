namespace HastaneSistemi.Models
{
    public class HastaListViewModel
    {
        public List<Hasta> YatanHastalar { get; set; }
        public List<Hasta> KritikBekleyenler { get; set; }
        public List<Hasta> NormalBekleyenler { get; set; }
    }
}
