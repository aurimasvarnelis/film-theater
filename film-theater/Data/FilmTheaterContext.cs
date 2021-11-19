using film_theater.Auth.Model;
using film_theater.Data.Dtos.Auth;
using film_theater.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace film_theater.Data
{
    public class FilmTheaterContext : IdentityDbContext<User>
    {
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        public FilmTheaterContext(DbContextOptions<FilmTheaterContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=FilmTheater");

        //    //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("MyDbConnection"));
        //}

    }
}
