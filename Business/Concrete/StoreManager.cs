using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class StoreManager : IStoreService
    {

        IStoreDal _storeDal;

        public StoreManager(IStoreDal storeDal)
        {
            _storeDal = storeDal;
        }

        public IDataResult<List<Store>> GetAll()
        {
            return new SuccessDataResult<List<Store>>(_storeDal.GetAll());
        }

        public IDataResult<Store> GetById(int id)
        {
            return new SuccessDataResult<Store>(_storeDal.Get(s => s.Id == id));
        }
    }
}
