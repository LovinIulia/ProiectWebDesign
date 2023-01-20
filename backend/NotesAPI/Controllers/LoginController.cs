using Microsoft.AspNetCore.Mvc;
using NotesAPI.Models;
using NotesAPI.Services;
using System;
using System.Threading.Tasks;

namespace NotesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        IUserCollectionService _userCollectionService;

        public LoginController(IUserCollectionService userCollectionService)
        {
            _userCollectionService = userCollectionService ?? throw new ArgumentNullException(nameof(userCollectionService));
        }

        /// <summary>
        /// Check user credentials
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> CheckCredentials(string username, string password)
        {
            var request = this.Request;
            return Ok(await _userCollectionService.CheckUserCredentials(username, password));
        }

        /// <summary>
        /// Create new user into database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (string.IsNullOrEmpty(user.Id))
            {
                user.Id = Guid.NewGuid().ToString();
            }
            if (user == null)
            {
                return BadRequest("User is null");
            }
            await _userCollectionService.Create(user);

            return CreatedAtRoute("GetUserById", new { userId = user.Id }, user);

        }
    }
}
