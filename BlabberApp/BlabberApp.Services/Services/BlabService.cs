using System;
using System.Collections;
using BlabberApp.DataStore;
using BlabberApp.Domain;

namespace BlabberApp.Services
{
    public class BlabService : IBlabService
    {
        private MySqlRepository<Blab> _repository;

        public BlabService()
        {
            //_repository = new MySqlRepository<Blab>();
        }

        public void AddBlab(Blab blab)
        {
            _repository.Insert(blab);
        }

        public IEnumerable GetAll()
        {
            return _repository.GetAll();
        }
    }
}