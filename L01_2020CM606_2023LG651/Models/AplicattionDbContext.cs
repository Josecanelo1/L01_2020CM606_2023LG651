using L01_2020CM606_2023LG651.Models.Tablas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace L01_2020CM606_2023LG651.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        DbSet<Publicaciones> Publicaciones { get; set; }
        DbSet<Comentarios> Comentarios { get; set; }
        DbSet<Calificaciones> Calificaciones { get; set; }
        DbSet<Roles> Roles { get; set; }
    }
}
