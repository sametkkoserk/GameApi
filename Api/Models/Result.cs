namespace Api.Models
{
    public class Result
    {
        public bool success { get; set; }

        public string message { get; set; }
    }

    public class GetOneResult<TEntitiy> : Result where TEntitiy : class, new()
    {
        public TEntitiy entity { get; set;}
    }
    public class GetManyResult<TEntitiy> : Result where TEntitiy : class, new()
    {
        public IEnumerable<TEntitiy> result { get; set; }
    }
}
