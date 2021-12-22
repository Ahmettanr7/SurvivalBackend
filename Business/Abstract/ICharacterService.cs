using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICharacterService
    {
        IDataResult<List<Character>> GetAll();
        IDataResult<Character> GetById(int id);
    }
}
