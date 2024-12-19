using AirCesiModel.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AirCesiModel.Context;
public class AirCesiContext(DbContextOptions<AirCesiContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Aeroport> Aeroports { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Compagnie> Compagnies { get; set; }
    public DbSet<Passager> Passagers { get; set; }
    public DbSet<Personne> Personnes { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Ville> Villes { get; set; }
    public DbSet<Vol> Vols { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        var connString = "server=localhost;database=aircesi;user=root;password=";
        optionsBuilder.UseMySql(connString, ServerVersion.AutoDetect(connString));
    }

}
