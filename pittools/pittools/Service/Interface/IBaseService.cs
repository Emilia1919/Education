using pittools.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pittools.Service.Interface
{
    public interface IBaseService<T> where T : class, IBase, new()
    {
        // Получение всех записей из таблицы БД
        IQueryable<T> Get();

        // Получение одной записи с заданным ID
        T Get(int id);

        // Получение нескольких записей.
        // Параметр skip - сколько первых записей пропустить, параметр take - сколько записей получить
        IQueryable<T> Get(int skip, int take);

        // Добавление записи в таблицу
        void Add(T dataObject);

        // Удаление записи из таблицы
        void Delete(T dataObject);

        // Сохранение внесённых изменений
        void Save();
    }
}