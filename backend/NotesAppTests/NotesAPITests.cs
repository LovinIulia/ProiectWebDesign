using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NotesAPI.Controllers;
using NotesAPI.Models;
using NotesAPI.Services;
using System.Threading.Tasks;

namespace NotesAppTests
{
    [TestClass]
    public class NotesAPITests
    {
        private Mock<INoteCollectionService> _noteServiceMock;
        private NotesController _controller;

        [TestMethod]
        public void GetNoteByIdIfTheIdIsValid()
        {
            // Arrange
            string id = "noteGuid";
            Note note = new Note();

            _noteServiceMock = new Mock<INoteCollectionService>();
            _noteServiceMock
                .Setup(m => m.Get(id))
                .Returns(Task.FromResult(note));
            _controller = new NotesController(_noteServiceMock.Object);

            // Act
            var result = _controller.GetNoteById(id).Result;

            // Assert
            var expectedNote = result as OkObjectResult;
            Assert.AreEqual(expectedNote.Value, note);
        }

        [TestMethod]
        public void ReturnsNotFoundForNoteWithInvalidId()
        {
            // Arrange
            string id = "noteGuid";
            _noteServiceMock = new Mock<INoteCollectionService>();
            _noteServiceMock
                .Setup(m => m.Get(id))
                .Returns(Task.FromResult((Note)null));
            _controller = new NotesController(_noteServiceMock.Object);

            // Act
            var result = _controller.GetNoteById(id).Result;

            // Assert
            var expectedNote = result as NotFoundObjectResult;
            Assert.AreEqual(expectedNote.Value, $"Note with id {id} not found");
        }

        [TestMethod]
        public void CreateNoteTest()
        {
            // Arrange
            Note noteToBeCreated = new Note();
            _noteServiceMock = new Mock<INoteCollectionService>();
            _controller = new NotesController(_noteServiceMock.Object);

            // Act
            var result = _controller.CreateNote(noteToBeCreated);

            // Assert
            _noteServiceMock.Verify(m => m.Create(noteToBeCreated), Moq.Times.Once);
        }

        [TestMethod]
        public void DeleteNoteTest()
        {
            // Arrange
            string id = "noteGuid";
            Note note = new Note();

            _noteServiceMock = new Mock<INoteCollectionService>();
            _noteServiceMock
                .Setup(m => m.Get(id))
                .Returns(Task.FromResult(note));
            _controller = new NotesController(_noteServiceMock.Object);

            // Act
            var result = _controller.DeleteNote(id);

            // Assert
            _noteServiceMock.Verify(m => m.Delete(id));
        }
    }
}
