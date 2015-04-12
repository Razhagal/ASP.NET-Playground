namespace Battleships.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using Battleships.Data;
    using Battleships.Models;
    using Battleships.Services.Models;

    [Authorize]
    public class GamesController : BaseApiController
    {
        //public GamesController(IBattleshipsData data)
        //    : base(data)
        //{
        //}
        
        public IHttpActionResult GetGamesCount()
        {
            var gamesCount = this.Data.Games.All().Count();
            return this.Ok(gamesCount);
        }

        [HttpPost]
        [ActionName("create")]
        public IHttpActionResult CreateGame()
        {
            var game = new Game()
            {
                PlayerOneId = this.User.Identity.GetUserId()
                // TODO: Generate ships
            };

            this.Data.Games.Add(game);
            this.Data.SaveChanges();

            return this.Ok(game.Id);
        }

        [HttpGet]
        [ActionName("all")]
        public IHttpActionResult GetAllAvailableGames()
        {
            var games = this.Data.Games
                .All()
                .Where(g => g.State == GameState.WaitingForPlayer)
                .Select(g => new
                {
                    Id = g.Id,
                    PlayerOne = g.PlayerOne.UserName,
                    State = g.State.ToString()
                })
                .ToList();

            return this.Ok(games);
        }

        [HttpPost]
        [ActionName("join")]
        public IHttpActionResult JoinGame(JoinGameBindingModel model)
        {
            var game = this.Data.Games
                .All()
                .Where(g => g.Id.ToString() == model.GameId)
                .FirstOrDefault();
            if (game == null)
            {
                return this.NotFound();
            }

            var userId = this.User.Identity.GetUserId();
            if (game.PlayerOneId == userId)
            {
                return this.BadRequest("You cannot join your own game.");
            }

            game.PlayerTwoId = userId;
            game.State = GameState.TurnOne;
            this.Data.SaveChanges();

            return this.Ok(game.Id);
        }
    }
}