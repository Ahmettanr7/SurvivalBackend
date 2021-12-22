using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CharacterManager : ICharacterService
    {

        private ICharacterDal _characterDal;

        public CharacterManager(ICharacterDal characterDal)
        {
            _characterDal = characterDal;
        }
        public IDataResult<List<Character>> GetAll()
        {
            return new SuccessDataResult<List<Character>>(_characterDal.GetAll(),"Karakterler Getirildi");
        }

        public IDataResult<Character> GetById(int id)
        {
            return new SuccessDataResult<Character>(_characterDal.Get(c => c.Id == id));
        }
    }
}
