using BlabberApp.DataStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class MySqlRepositoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Insert_EntityIsNull()
        {
            // Arrange
            var repository = new MySqlRepository<TestEntity>(new Context(null));

            // Act
            repository.Insert(null);

            // Assert
        }

        [TestMethod]
        public void Insert_Success()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<TestEntity>>();
            mockDbSet.Setup(d => d.Add(It.IsAny<TestEntity>()));

            var mockContext = new Mock<IContext>();
            mockContext.Setup(c => c.Set<TestEntity>()).Returns(mockDbSet.Object);
            mockContext.Setup(c => c.SaveChanges());

            var repository = new MySqlRepository<TestEntity>(mockContext.Object);

            // Act
            repository.Insert(new TestEntity());

            // Assert
            mockDbSet.Verify(d => d.Add(It.IsAny<TestEntity>()), Times.Once);
            mockContext.Verify(c => c.Set<TestEntity>(), Times.Once);
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Update_EntityIsNull()
        {
            // Arrange
            var repository = new MySqlRepository<TestEntity>(new Context(null));

            // Act
            repository.Update(null);

            // Assert
        }

        [TestMethod]
        public void Update_Success()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<TestEntity>>();
            mockDbSet.Setup(d => d.Update(It.IsAny<TestEntity>()));

            var mockContext = new Mock<IContext>();
            mockContext.Setup(c => c.Set<TestEntity>()).Returns(mockDbSet.Object);
            mockContext.Setup(c => c.SaveChanges());

            var repository = new MySqlRepository<TestEntity>(mockContext.Object);

            // Act
            repository.Update(new TestEntity());

            // Assert
            mockDbSet.Verify(d => d.Update(It.IsAny<TestEntity>()), Times.Once);
            mockContext.Verify(c => c.Set<TestEntity>(), Times.Once);
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Delete_EntityIsNull()
        {
            // Arrange
            var repository = new MySqlRepository<TestEntity>(new Context(null));

            // Act
            repository.Delete(null);

            // Assert
        }

        [TestMethod]
        public void Delete_Success()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<TestEntity>>();
            mockDbSet.Setup(d => d.Remove(It.IsAny<TestEntity>()));

            var mockContext = new Mock<IContext>();
            mockContext.Setup(c => c.Set<TestEntity>()).Returns(mockDbSet.Object);
            mockContext.Setup(c => c.SaveChanges());

            var repository = new MySqlRepository<TestEntity>(mockContext.Object);

            // Act
            repository.Delete(new TestEntity());

            // Assert
            mockDbSet.Verify(d => d.Remove(It.IsAny<TestEntity>()), Times.Once);
            mockContext.Verify(c => c.Set<TestEntity>(), Times.Once);
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void GetById_ReturnNull()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<TestEntity>>();
            var mockContext = new Mock<IContext>();
            mockContext.Setup(c => c.Set<TestEntity>()).Returns(mockDbSet.Object);

            var repository = new MySqlRepository<TestEntity>(mockContext.Object);

            // Act
            var actual = repository.GetById(-1);

            // Assert
            mockContext.Verify(c => c.Set<TestEntity>(), Times.Once);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetById_Success()
        {
            // Arrange
            var expected = new TestEntity { Id = 22, Name = "HelloWorld" };

            var mockDbSet = new Mock<DbSet<TestEntity>>();
            mockDbSet.Setup(d => d.Find(22)).Returns(expected);

            var mockContext = new Mock<IContext>();
            mockContext.Setup(c => c.Set<TestEntity>()).Returns(mockDbSet.Object);

            var repository = new MySqlRepository<TestEntity>(mockContext.Object);

            // Act
            var actual = repository.GetById(22);

            // Assert
            mockDbSet.Verify(d => d.Find(22), Times.Once);
            mockContext.Verify(c => c.Set<TestEntity>(), Times.Once);
            
            Assert.AreEqual(expected, actual);
        }
    }
}