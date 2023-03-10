using MongoDB.Driver;
using NotesAPI.Models;
using NotesAPI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Services
{
    public class NoteCollectionService : INoteCollectionService
    {
        private readonly IMongoCollection<Note> _notes;

        public NoteCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _notes = database.GetCollection<Note>(settings.NoteCollectionName);
        }

        public async Task<Note> Get(string noteId)
        {
            return (await _notes.FindAsync(note => note.Id == noteId)).FirstOrDefault();
        }

        public async Task<List<Note>> GetAll()
        {
            var result = await _notes.FindAsync(note => true);
            return result.ToList();
        }

        public async Task<bool> Create(Note note)
        {
            if(string.IsNullOrEmpty(note.Id))
            {
                note.Id = Guid.NewGuid().ToString();
            }
            await _notes.InsertOneAsync(note);
            return true;
        }

        public async Task<bool> Update(string id, Note note)
        {
            note.Id = id;
            var result = await _notes.ReplaceOneAsync(note => note.Id == id, note);
            if(!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _notes.InsertOneAsync(note);
                return false;
            }
            return true;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _notes.DeleteOneAsync(note => note.Id == id);
            if (result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;
            
        }

    }
}
