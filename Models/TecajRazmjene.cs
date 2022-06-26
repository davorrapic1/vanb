namespace Models
{
    public class TecajRazmjene
    {
        public Guid Id { get; set; }
        public DateTime DatumPrimjene { get; set; }
        public string BrojTecajnice { get; set; }
        public string Drzava { get; set; }
        public string DrzavaIso { get; set; }
        public string SifraValute { get; set; }
        public string Valuta { get; set; }
        public string Jedinica { get; set; }
        public string SrednjiTecaj { get; set; }
        public string ProdajniTecaj { get; set; }
        public string KupovniTecaj { get; set; }
    }

    public class Tecajevi
    {
        public IEnumerable<TecajRazmjene> TecajeviRazmjene { get; set; }
    }
}