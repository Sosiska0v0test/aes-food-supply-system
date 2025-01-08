using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();  // Отримати всі записи
        T Get(int id);           // Отримати запис за ідентифікатором
        void Create(T item);     // Додати новий запис
        void Update(T item);     // Оновити існуючий запис
        void Delete(int id);     // Видалити запис за ідентифікатором
    }
}

