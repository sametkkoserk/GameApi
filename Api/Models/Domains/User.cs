namespace Api.Models.Domains
{
    public class User
    {
        public Guid id { get; set; }
        public string userName { get; set; }
        public string? FullName { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime lastPlayDate { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}
