using Microsoft.AspNetCore.Mvc;
using NotesAPI.Models;
using NotesAPI.Services;
using System;
using System.Threading.Tasks;

namespace NotesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        INoteCollectionService _noteCollectionService;
        public NotesController(INoteCollectionService noteCollectionService)
        {
            _noteCollectionService = noteCollectionService ?? throw new ArgumentNullException(nameof(noteCollectionService));
        }

        /// <summary>
        /// Get all notes.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            return Ok(await _noteCollectionService.GetAll());
        }

        /// <summary>
        /// Add a new note.
        /// </summary>
        /// <response code="200">Success creating one note.</response>
        /// <response code="201">Success getting location header in post response.</response>
        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] Note note)
        {
            if (string.IsNullOrEmpty(note.Id))
            {
                note.Id = Guid.NewGuid().ToString();
            }
            if (note == null)
            {
                return BadRequest("Note is null");
            }
            await _noteCollectionService.Create(note);

            return CreatedAtRoute("GetNoteById", new { noteId = note.Id }, note);

        }

        /// <summary>
        /// Update note by NoteId.
        /// </summary>
        /// <response code="200">Success updating note.</response>
        /// <response code="404">Updating the note failed because of invalid id.</response>
        /// <returns>Updated note</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateNoteById([FromBody] Note note)
        {
            if (note == null)
            {
                return NotFound("Please provide Note body");
            }
            await _noteCollectionService.Update(note.Id, note);

            return Ok(note);
        }

        /// <summary>
        /// Delete note by NoteId.
        /// </summary>
        /// <response code="200">Success deleting note.</response>
        /// <response code="404">Deleting the note failed because of invalid id.</response>
        /// <returns>Ok. The note was deleted</returns>
        [HttpDelete("note/{id}")]
        public async Task<IActionResult> DeleteNote(string id)
        {
            bool ok = await _noteCollectionService.Delete(id);
            if (!ok)
            {
                return NotFound("Note not found");
            }
            return Ok("Note was deleted");
        }

        /// <summary>
        /// Get one note by NoteId.
        /// </summary>
        /// <response code="200">Success getting one note from the list.</response>
        /// <response code="404">Getting the note failed because of invalid id.</response>
        /// <returns>Returns one note from the list</returns>
        [HttpGet("note/{noteId}", Name = "GetNoteById")]
        public async Task<IActionResult> GetNoteById(string noteId)
        {
            var note = await _noteCollectionService.Get(noteId);
            if (note == null)
            {
                return NotFound($"Note with id {noteId} not found");
            }
            return Ok(note);
        }

    }
}



