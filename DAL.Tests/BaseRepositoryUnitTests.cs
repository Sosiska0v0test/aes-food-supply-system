using DAL.Entities;
using DAL.Tests;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {
        private Mock<DbSet<Dishes>> CreateMockDbSet(IEnumerable<Dishes> data)
        {
            var queryable = data.AsQueryable();

            var mockSet = new Mock<DbSet<Dishes>>();
            mockSet.As<IQueryable<Dishes>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<Dishes>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<Dishes>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<Dishes>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            mockSet.Setup(m => m.Add(It.IsAny<Dishes>())).Callback<Dishes>(data.ToList().Add);
            mockSet.Setup(m => m.Remove(It.IsAny<Dishes>())).Callback<Dishes>(dish => data.ToList().Remove(dish));

            return mockSet;
        }

        private Mock<DbContext> CreateMockDbContext(IEnumerable<Dishes> data)
        {
            var mockSet = CreateMockDbSet(data);
            var mockContext = new Mock<DbContext>();
            mockContext.Setup(c => c.Set<Dishes>()).Returns(mockSet.Object);
            return mockContext;
        }

        [Fact]
        public void Create_AddsNewEntity()
        {
            // Arrange
            var mockData = new List<Dishes>();
            var mockContext = CreateMockDbContext(mockData);
            var repository = new TestDishesRepository(mockContext.Object);

            var dish = new Dishes { DishName = "Pizza", Description = "Cheese Pizza", Calories = 300, Price = 12.5m };

            // Act
            repository.Create(dish);

            // Assert
            Assert.Contains(dish, mockData);
        }

        [Fact]
        public void Delete_RemovesEntityById()
        {
            // Arrange
            var dish = new Dishes { DishID = 1, DishName = "Burger", Description = "Beef Burger", Calories = 500, Price = 8.99m };
            var mockData = new List<Dishes> { dish };
            var mockContext = CreateMockDbContext(mockData);
            var repository = new TestDishesRepository(mockContext.Object);

            // Act
            repository.Delete(dish.DishID);

            // Assert
            Assert.DoesNotContain(dish, mockData);
        }

        [Fact]
        public void GetAll_ReturnsAllEntities()
        {
            // Arrange
            var mockData = new List<Dishes>
            {
                new Dishes { DishName = "Pizza", Description = "Cheese Pizza" },
                new Dishes { DishName = "Pasta", Description = "Italian Pasta" }
            };
            var mockContext = CreateMockDbContext(mockData);
            var repository = new TestDishesRepository(mockContext.Object);

            // Act
            var result = repository.GetAll();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void Update_UpdatesEntity()
        {
            // Arrange
            var dish = new Dishes { DishID = 1, DishName = "Pizza", Description = "Cheese Pizza", Calories = 300, Price = 12.5m };
            var mockData = new List<Dishes> { dish };
            var mockContext = CreateMockDbContext(mockData);
            var repository = new TestDishesRepository(mockContext.Object);

            // Act
            dish.Description = "Updated Cheese Pizza";
            repository.Update(dish);

            // Assert
            Assert.Equal("Updated Cheese Pizza", mockData.First().Description);
        }
    }
}
