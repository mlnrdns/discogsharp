namespace discogsharp.Domain
{
    public class MasterVersion : Resource
    {
        public string Title { get; set; }
        public string Status { get; set; }
        public string Thumb { get; set; }
        public string Country { get; set; }
        public string Format { get; set; }
        public string Label { get; set; }
        public string Released { get; set; }
        public string Catno { get; set; }
    }
}