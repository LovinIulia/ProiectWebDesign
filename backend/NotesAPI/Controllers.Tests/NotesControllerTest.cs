using Moq;
using NotesAPI.Models;
using NotesAPI.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace NotesAPI.Controllers.Tests
{
    [TestFixture]
    public class NotesControllerTest
    {
        private Mock<INoteCollectionService> _noteServiceMock;
        private NotesController _controller;

        public NotesControllerTest()
        {
        }

        //[SetUp]
        //public void Setup()
        //{
        //    _noteServiceMock = new Mock<INoteCollectionService>();
        //    _controller = new NotesController(_noteServiceMock.Object);
        //}

        //[Test]
        //public void GetNoteById_WithValidId_ReturnsExpectedNote()
        //{
        //    // arrange
        //    string id = "noteGuid";
        //    Note note = new Note();

        //    _noteServiceMock
        //        .Setup(m => m.Get(id))
        //        .Returns(Task.FromResult(note));

        //    // act
        //    var expectedNote = _controller.GetNoteById(id);

        //    // assert
        //    Assert.That(expectedNote, Is.EqualTo(note));        
        //}
    }
}
