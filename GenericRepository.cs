using System;
using System.Collections.Generic;

namespace PostLogisticsApp
{
    // Узагальнений репозиторій для роботи з колекцією сутностей у пам'яті
    public class GenericRepository<T> : IRepository<T> where T : Model
    {
        // Статичне внутрішнє сховище для конкретного закритого типу T
        private static readonly List<T> _storage = new List<T>();

        public void Add(T entity)
        {
            if (entity == null) return;
            _storage.Add(entity);
            Console.WriteLine($">> Додано запис (ID: {entity.Id})");
        }

        public T GetById(int id)
        {
            foreach (var item in _storage)
            {
                if (item.Id == id)
                    return item;
            }
            return null;
        }

        public List<T> GetAll()
        {
            return new List<T>(_storage);
        }

        public void Update(T entity)
        {
            if (entity == null) return;

            for (int i = 0; i < _storage.Count; i++)
            {
                if (_storage[i].Id == entity.Id)
                {
                    _storage[i] = entity;
                    Console.WriteLine($">> Оновлено запис (ID: {entity.Id})");
                    return;
                }
            }

            Console.WriteLine($"[Увага] Запис з ID {entity.Id} відсутній у базі.");
        }

        public void Delete(int id)
        {
            var target = GetById(id);
            if (target != null)
            {
                _storage.Remove(target);
                Console.WriteLine($">> Вилучено запис (ID: {id})");
            }
            else
            {
                Console.WriteLine($"[Увага] Запис з ID {id} не знайдено для вилучення.");
            }
        }
    }
}
