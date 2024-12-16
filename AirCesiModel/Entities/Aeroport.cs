using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AirCesiModel.Entities;
public class Aeroport
{
    public int Id { get; set; }

    [StringLength(100)]
    public string Nom { get; set; } = string.Empty;

    //relation * 1 avec l'entité Vol : Vols départs
    [InverseProperty(nameof(Vol.AeroportDepart))]
    [JsonIgnore]
    public List<Vol>? VolDeparts { get; set; }

    //relation * 1 avec l'entité Vol : Vols arrivées
    [InverseProperty(nameof(Vol.AeroportArrivee))]
    [JsonIgnore]
    public List<Vol>? VolArrivees { get; set; }

    //relation * * avec l'entité Ville
    public List<Ville>? Villes { get; set; }
}
