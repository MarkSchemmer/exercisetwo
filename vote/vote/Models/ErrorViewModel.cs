using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace vote.Models
{

    public class GameContext : DbContext
    {

        public DbSet<Game> game { get; set; }

        public GameContext(DbContextOptions<GameContext> options) : base(options) { }
    }

    public class Game
    {
        [Key]
        public int Id { get; set; }


        public int Count { get; set; }

        public int Male { get; set; }

        public int Femail { get; set; }

    }

    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}