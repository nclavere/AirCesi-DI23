using AirCesiModel.Context;
using AirCesiModel.Entities;

namespace AirCesiModel.DatasTest;

public static class InitialSeed
{
    public static void SeedDatas()
    {
        using (var context = new AirCesiContext())
        {
            if(context.Compagnies.Any())
            {
                return; //le jeu de test existe déjà
            }

            context.Compagnies.Add( new Compagnie { Nom = "Air France"});
            context.Compagnies.Add( new Compagnie { Nom = "Ryanair"});
            context.Compagnies.Add( new Compagnie { Nom = "Volotea" });
            context.Compagnies.Add( new Compagnie { Nom = "Easy Jet" });
            context.SaveChanges();

            context.Villes.Add(new Ville { Nom = "Paris" });
            context.Villes.Add(new Ville { Nom = "Londres" });
            context.Villes.Add(new Ville { Nom = "Madrid" });
            context.Villes.Add(new Ville { Nom = "Rome" });
            context.Villes.Add(new Ville { Nom = "Pau" });
            context.Villes.Add(new Ville { Nom = "Bâle" });
            context.Villes.Add(new Ville { Nom = "Mulhouse" });
            context.SaveChanges();

            context.Aeroports.Add(new Aeroport { 
                Nom = "Orly", 
                Villes = new List<Ville> { context.Villes.First(v => v.Nom == "Paris") }
            });
            context.Aeroports.Add(new Aeroport
            {
                Nom = "Roissy",
                Villes = new List<Ville> { context.Villes.First(v => v.Nom == "Paris") }
            });
            context.Aeroports.Add(new Aeroport
            {
                Nom = "Air'PY",
                Villes = new List<Ville> { context.Villes.First(v => v.Nom == "Pau") }
            });
            context.Aeroports.Add(new Aeroport
            {
                Nom = "Standsted",
                Villes = new List<Ville> { context.Villes.First(v => v.Nom == "Londres") }
            });
            context.Aeroports.Add(new Aeroport
            {
                Nom = "Adolfo Suarez",
                Villes = new List<Ville> { context.Villes.First(v => v.Nom == "Madrid") }
            });
            context.Aeroports.Add(new Aeroport
            {
                Nom = "Léonard de Vinci",
                Villes = new List<Ville> { context.Villes.First(v => v.Nom == "Rome") }
            });
            context.Aeroports.Add(new Aeroport
            {
                Nom = "Bâle Mulhouse",
                Villes = new List<Ville> { 
                    context.Villes.First(v => v.Nom == "Bâle"), 
                    context.Villes.First(v => v.Nom == "Mulhouse") }
            });
            context.SaveChanges();

        }


    } 
}
