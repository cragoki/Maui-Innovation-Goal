using SQLite;

namespace MauiApp1.Entities
{
    public class BaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool Synced { get; set; }
    }
}
