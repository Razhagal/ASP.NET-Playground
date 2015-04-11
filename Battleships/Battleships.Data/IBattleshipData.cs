namespace Battleships.Data
{
    using Battleships.Data.Repositories;
    using Battleships.Models;

    public interface IBattleshipData
    {
        GamesRepository Games { get; }

        IRepository<Ship> Ships { get; }

        int SaveChanges();
    }
}
