using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class GameManager : IGameService
    {

        IGameDal _gameDal;
        IEnemyDal _enemyDal;
        IStoreDal _storeDal;

        public GameManager(IGameDal gameDal, IEnemyDal enemyDal, IStoreDal storeDal)
        {
            _gameDal = gameDal;
            _enemyDal = enemyDal;
            _storeDal = storeDal;
        }
        public IResult Add(Game game)
        {
            _gameDal.Add(game);
            return new SuccessResult(game.Id.ToString());
        }

        public IDataResult<List<Game>> GetAll()
        {
            return new SuccessDataResult<List<Game>>(_gameDal.GetAll());
        }

        public IDataResult<Game> GetById(int id)
        {
            return new SuccessDataResult<Game>(_gameDal.Get(g => g.Id == id));
        }

        public IResult War(int gameId, int enemyId)
        {
            Game WillBeUpdateGame = _gameDal.Get(g => g.Id == gameId);
            Enemy enemy = _enemyDal.Get(e => e.Id == enemyId);

            if (WillBeUpdateGame.Healty < enemy.Healty)
            {
                WillBeUpdateGame.Healty = 0;
            }
            else
            {
                WillBeUpdateGame.TotalPoint += enemy.Point;
                WillBeUpdateGame.Healty -= enemy.Healty;
            }



            _gameDal.Update(WillBeUpdateGame);
            return new SuccessResult("Puan Kaydedildi");
        }

        public IResult Escape(int gameId, int enemyId)
        {
            Game WillBeUpdateGame = _gameDal.Get(g => g.Id == gameId);
            Enemy enemy = _enemyDal.Get(e => e.Id == enemyId);
            WillBeUpdateGame.Money -= enemy.ForcedTax;
            _gameDal.Update(WillBeUpdateGame);
            return new SuccessResult("Puan Kaydedildi");
        }

        public IResult Shopping(int gameId, int itemId)
        {
            Game WillBeUpdateGame = _gameDal.Get(g => g.Id == gameId);
            Store item = _storeDal.Get(s => s.Id == itemId);
            WillBeUpdateGame.Money -= item.Price;
            WillBeUpdateGame.Healty += item.Amount;
            _gameDal.Update(WillBeUpdateGame);
            return new SuccessResult("Alışveriş Başarılı");
        }
    }
}
