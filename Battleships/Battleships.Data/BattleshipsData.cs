namespace Battleships.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Battleships.Data.Repositories;
    using Battleships.Models;

    public class BattleshipsData : IBattleshipsData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public BattleshipsData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public GamesRepository Games
        {
            get { return (GamesRepository)this.GetRepository<Game>(); }
        }

        public IRepository<Ship> Ships
        {
            get { return this.GetRepository<Ship>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var type = typeof(Repository<T>);
                if (typeOfRepository.IsAssignableFrom(typeof(Game)))
                {
                    type = typeof(GamesRepository);
                }

                var repository = Activator.CreateInstance(type, this.context);
                this.repositories.Add(typeOfRepository, repository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
