using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using NotesAPI.Models;
using NotesAPI.Settings;

namespace NotesAPI.Services
{
    public class UserCollectionService : IUserCollectionService
    {
        private readonly IMongoCollection<User> _users;

        public UserCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UserCollectionName);
        }

        public UserCollectionService() { }

        public async Task<bool> CheckUserCredentials(string username, string password)
        {
            return (await _users.FindAsync(user => user.Name == username && user.Password == password)).FirstOrDefault() != null;
        }

        public async Task<bool> Create(User user)
        {
            if (string.IsNullOrEmpty(user.Id))
            {
                user.Id = Guid.NewGuid().ToString();
            }
            await _users.InsertOneAsync(user);

            return true;
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(string id, User model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
