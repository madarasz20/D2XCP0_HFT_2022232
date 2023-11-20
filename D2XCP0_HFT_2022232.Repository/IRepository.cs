﻿using D2XCP0_HFT_2022232.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        T Read(int id);
        IQueryable<T> ReadAll();
        void Update(T item);
        void Delete(int id);
    }
}
