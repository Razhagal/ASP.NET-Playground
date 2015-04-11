namespace Battleships.Data.Repositories
{
    using System.Linq;
    using System.Data.Entity;

    using Battleships.Models;

    public class GamesRepository : Repository<Game>
    {
        public GamesRepository(DbContext context)
            : base(context)
        {
        }

        public IQueryable<Game> GetGamesByState(GameState state)
        {
            return this.Set.Where(s => s.State == state);
        }
    }
}