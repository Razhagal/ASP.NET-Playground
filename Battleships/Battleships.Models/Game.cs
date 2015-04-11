namespace Battleships.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        public Game()
        {
            this.Id = new Guid();
            this.Field = new string('O', 64);
            this.State = GameState.WaitingForPlayer;
        }

        public Guid Id { get; set; }

        public string Field { get; set; }

        public GameState State { get; set; }

        [Required]
        public string PlayerOneId { get; set; }

        public virtual User PlayerOne { get; set; }

        public string PlayerTwoId { get; set; }

        public virtual User PlayerTwo { get; set; }
    }
}
