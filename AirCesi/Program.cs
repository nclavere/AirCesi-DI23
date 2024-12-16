using AirCesiModel.DatasTest;
using AirCesiModel.Context;
using Microsoft.EntityFrameworkCore;

//1ere étape : création des données de test
InitialSeed.SeedDatas();

//2eme étape : update des données incomplètes (pour exemple)
using(var context = new AirCesiContext())
{
    var aeroport = context.Aeroports.FirstOrDefault(v => v.Nom == "Roissy");
    if(aeroport != null)
    {
        //mise à jour
        aeroport.Nom = "Roissy Charles de Gaulle";
        context.SaveChanges();

        //suppression 
        //context.Aeroports.Remove(aeroport);
        //context.SaveChanges();
    }    
}


// Génération du script sql
//using (var context = new AirCesiContext())
//{
//    var sql = context.Database.GenerateCreateScript();
//    System.IO.File.WriteAllText("aircesi.sql", sql);
//    Console.WriteLine(sql);
//}

using (var context = new AirCesiContext())
{
    // Lister les aéroports dont le nom commence par "A"
    var aeroports = context.Aeroports
        .Include(a => a.Villes)
        .Where(a => a.Nom.StartsWith("A"))        
        .Select(a => new { AeroportNom = a.Nom, VilleNom = a.Villes!.First().Nom })
        .OrderBy(a => a.AeroportNom)
        .ToList();

    foreach (var aeroport in aeroports)
    {
        Console.WriteLine(aeroport.AeroportNom + " -> ville : " + aeroport.VilleNom);
    }


    // Liste le nombre d'aéroports
    int nb = context.Aeroports.Count();
    Console.WriteLine($"Nombre d'aéroports : {nb}");

    // Lister les aéroports de Paris
    var aeroports2 = context.Aeroports
        .Include(a => a.Villes)
        .Where(a => a.Villes!.Any(v => v.Nom == "Paris"))
        .Select(a => new { AeroportNomParis = a.Nom })
        .OrderBy(a => a.AeroportNomParis)
        .ToList();
    foreach (var aeroport in aeroports2)
    {
        Console.WriteLine(aeroport.AeroportNomParis + " dans la ville de Paris");
    }

    // Lister les aéroports qui ont plusieurs villes
    // Lister les aéroports qui ont plusieurs villes
    var aeroportsAvecPlusieursVilles = context.Aeroports
        .Include(a => a.Villes)
        .Where(a => a.Villes!.Count() > 1)
        .Select(a => new
        {
            AeroportNom = a.Nom,
            Villes = a.Villes!.Select(v => v.Nom).ToList()
        })
        .OrderBy(a => a.AeroportNom)
        .ToList();

    Console.WriteLine("\nListe des aéroports associés à plusieurs villes :");
    foreach (var aeroport in aeroportsAvecPlusieursVilles)
    {
        Console.WriteLine(aeroport.AeroportNom + " est associé aux villes : " + string.Join(", ", aeroport.Villes));
    }

}





Console.ReadKey();

