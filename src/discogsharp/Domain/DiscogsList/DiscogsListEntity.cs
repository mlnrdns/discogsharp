namespace discogsharp.Domain
{
    public abstract class DiscogsListEntity : Resource
    {
        public string? Comment { get; set; }
        public string? DisplayTitle { get; set; }
        public string? ImageUrl { get; set; }
        public ResourceType Type { get; set; }
        public string? Uri { get; set; }
    }
}
