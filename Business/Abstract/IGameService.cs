using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IGameService
    {
        IResult Add(Game game);
        IResult War(int gameId, int enemyId);
        IResult Escape(int gameId, int enemyId);

        IResult Shopping(int gameId, int itemId);

        IDataResult<List<Game>> GetAll();

        IDataResult<Game> GetById(int id);

    }
}
