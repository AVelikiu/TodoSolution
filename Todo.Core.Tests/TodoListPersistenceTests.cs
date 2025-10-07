using Xunit;
using System.IO;
using Todo.Core;

namespace Todo.Core.Tests
{
    public class TodoListPersistenceTests
    {
        [Fact]
        public void SaveAndLoad_WorksCorrectly()
        {
            // Arrange
            var path = "test_todos.json";
            if (File.Exists(path)) File.Delete(path);

            var list = new TodoList();
            list.Add("Task A");
            list.Add("Task B");
            list.Items[1].MarkDone();

            // Act
            list.Save(path);
            var loaded = TodoList.Load(path);

            // Assert
            Assert.Equal(list.Count, loaded.Count);
            Assert.Equal(list.Items[0].Title, loaded.Items[0].Title);
            Assert.Equal(list.Items[1].IsDone, loaded.Items[1].IsDone);

            File.Delete(path);
        }
    }
}
