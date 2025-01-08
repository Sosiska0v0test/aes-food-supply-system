using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDishesRepository Dishes { get; }
        IMenusRepository Menus { get; }
        IMenuDishesRepository MenuDishes { get; }
        IWorkerDishViewsRepository WorkerDishViews { get; }
        IWorkersRepository Workers { get; }

        void Save(); // Зберігає всі зміни у базі даних
    }
}
