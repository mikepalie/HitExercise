﻿using HitExercise.Models;
using System.Collections.Generic;

namespace HitExercise.Interfaces.Repositories
{
    public interface ISupplierRepository
    {
        IEnumerable<Models.Supplier> GetAll();
        void Add(Models.Supplier supplier);
        void Update(Models.Supplier supplier); 
        void Delete(Models.Supplier supplier);
        Models.Supplier GetById(int id);
        bool ExistsWithName(string name);
        bool ExistsEditableName(string name);
        public bool isAfmValid(string afmNumber);
        public void Dispose();
    }
}
