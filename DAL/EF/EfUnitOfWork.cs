using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly AesFoodSupplyContext _context;
        private DishesRepository _dishesRepository;
        private MenusRepository _menusRepository;
        private MenuDishesRepository _menuDishesRepository;
        private WorkerDishViewsRepository _workerDishViewsRepository;
        private WorkersRepository _workersRepository;

        public EFUnitOfWork(DbContextOptions<AesFoodSupplyContext> options)
        {
            _context = new AesFoodSupplyContext(options);
        }

        public IDishesRepository Dishes
        {
            get
            {
                if (_dishesRepository == null)
                    _dishesRepository = new DishesRepository(_context);
                return _dishesRepository;
            }
        }

        public IMenusRepository Menus
        {
            get
            {
                if (_menusRepository == null)
                    _menusRepository = new MenusRepository(_context);
                return _menusRepository;
            }
        }

        public IMenuDishesRepository MenuDishes
        {
            get
            {
                if (_menuDishesRepository == null)
                    _menuDishesRepository = new MenuDishesRepository(_context);
                return _menuDishesRepository;
            }
        }

        public IWorkerDishViewsRepository WorkerDishViews
        {
            get
            {
                if (_workerDishViewsRepository == null)
                    _workerDishViewsRepository = new WorkerDishViewsRepository(_context);
                return _workerDishViewsRepository;
            }
        }

        public IWorkersRepository Workers
        {
            get
            {
                if (_workersRepository == null)
                    _workersRepository = new WorkersRepository(_context);
                return _workersRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
