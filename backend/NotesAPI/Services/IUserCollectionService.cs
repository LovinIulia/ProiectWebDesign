using NotesAPI.Models;
using System.Threading.Tasks;

namespace NotesAPI.Services
{
    public interface IUserCollectionService : ICollectionService<User>
    {
        Task<bool> CheckUserCredentials(string username, string password); 
    }
}
