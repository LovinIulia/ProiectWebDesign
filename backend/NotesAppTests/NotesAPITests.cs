using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using Moq;
using NotesAPI.Controllers;
using NotesAPI.Models;
using NotesAPI.Services;
using static NotesAPI.Controllers.NotesController;
using Xunit;
using System.Threading.Tasks;

namespace NotesAppTests
{
    //[TestClass]
    public class NotesAPITests
    {
        //private Mock<INoteCollectionService> _noteServiceMock;
        //private NotesController _controller;

        //[TestMethod]
        //public void TestMethod1()
        //{
        //    // Arrange
        //    _noteServiceMock = new Mock<INoteCollectionService>();
        //    _controller = new NotesController(_noteServiceMock.Object);
        //    string id = "noteGuid";
        //    Note note = new Note();

        //    // Act
        //    var expectedNote = _controller.GetNoteById(id);

        //    // Assert
        //    Assert.AreEqual(expectedNote, note);
        //}

        //[TestMethod]
        //public void ListAllNotes()
        //{
        //    // Arrange      
        //    var note = A.Fake<NoteCollectionService>();

        //    // Act
        //    var notes = A.CallTo(() => note.GetAll());         

        //    // Assert
        //    Assert.IsNotNull(notes);
        //}

        private IMongoCollection<Note> _notes;
        private Note _output;
        public NotesAPITests(Note output)
        {
            _output = output;
        }

        [Fact]
        public async Task ListAllNotes()
        {
               
        }
    }
}
