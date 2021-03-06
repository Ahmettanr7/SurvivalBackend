using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEnemyService
    {
        IDataResult<List<Enemy>> GetAll();
        IDataResult<Enemy> GetById(int id);
    }
}
