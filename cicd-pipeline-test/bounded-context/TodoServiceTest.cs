using crosscutting.validation;
using Moq;
using NUnit.Framework;
using todo_bcontext.infrastructure;
using todo_bcontext.service;

namespace cicd_pipeline_test
{
    public class TodoServiceTest
    {
        private Mock<IRepository> _repositoryMock;

        [SetUp]
        public void Setup()
        {

            _repositoryMock = new Mock<IRepository>();
        }

        [Test]
        public void Should_Create_A_Todo()
        {
            var todoStub = TodoModelStub.GetSimpleTodo();

            _repositoryMock.Setup(p => p.Add(todoStub)).Returns(todoStub);

            var todoService = new TodoService(_repositoryMock.Object);

            var (validation, result) = todoService.Create(todoStub);

            Assert.AreEqual(null, validation);
        }

        [Test]
        public void Should_Create_A_Todo_WithoutDefaultId()
        {
            var todoStub = TodoModelStub.GetSimpleTodo();

            _repositoryMock.Setup(p => p.Add(todoStub)).Returns(todoStub);

            var todoService = new TodoService(_repositoryMock.Object);

            var (validation, result) = todoService.Create(todoStub);

            Assert.AreEqual(null, validation);
        }

        [Test]
        public void Should_Refuse_To_Create_A_Todo_InvalidName()
        {
            var todoStub = TodoModelStub.GetSimpleTodo();

            todoStub.Name = "";

            _repositoryMock.Setup(p => p.Add(todoStub)).Returns(todoStub);

            var todoService = new TodoService(_repositoryMock.Object);

            var (validation, result) = todoService.Create(todoStub);

            Assert.IsFalse(validation == null);
            Assert.IsTrue(validation.Errors.Count > 0);
        }

        [Test]
        public void Should_Refuse_To_Create_A_Todo_InvalidDate()
        {
            var todoStub = TodoModelStub.GetSimpleTodo();

            todoStub.Expires = todoStub.Expires.AddDays(-2);

            _repositoryMock.Setup(p => p.Add(todoStub)).Returns(todoStub);

            var todoService = new TodoService(_repositoryMock.Object);

            var (validation, result) = todoService.Create(todoStub);

            Assert.IsFalse(validation == null);
            Assert.IsTrue(validation.Errors.Count > 0);
        }
    }
}