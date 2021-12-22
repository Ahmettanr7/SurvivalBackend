using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class EnemyManager : IEnemyService
    {

        IEnemyDal _enemyDal;

        public EnemyManager(IEnemyDal enemyDal)
        {
            _enemyDal = enemyDal;
        }
        public IDataResult<List<Enemy>> GetAll()
        {
            return new SuccessDataResult<List<Enemy>>(_enemyDal.GetAll());
        }

        public IDataResult<Enemy> GetById(int id)
        {
            return new SuccessDataResult<Enemy>(_enemyDal.Get(e => e.Id == id));
        }
    }
}
