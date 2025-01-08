using DAL.Entities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

namespace DAL.Tests
{
    public class TestDishesRepository : BaseRepository<Dishes>
    {
        public TestDishesRepository(DbContext context) : base(context)
        {
        }
    }
}
