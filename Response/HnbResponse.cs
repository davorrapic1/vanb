namespace Response 
{
    public class HnbResponse
    {
    
        public HttpResponseObject[] HttpResponseObjects { get; set; }

    }


    public class HttpResponseObject
    {

        public string Datum { get; set; } = null!;
        public string Par { get; set; } = null!;
        public string Valuta { get; set; } = null!;
        public string Vrijednost { get; set; } = null!;
    }
}