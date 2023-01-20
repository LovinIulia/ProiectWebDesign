namespace NotesAPI.Settings
{
    public interface IMongoDBSettings
    {
        string UserCollectionName { get; set; }
        string NoteCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
       
    }
}
