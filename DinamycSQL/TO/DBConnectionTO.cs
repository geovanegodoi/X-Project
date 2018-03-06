namespace DinamycSQL.TO
{
    public class DBConnectionTO
    {
        public string ConnectionString { get; set; }

        public string ProviderName { get; set; }

        public bool UseTransaction { get; set; }
    }
}