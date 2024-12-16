using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AirCesiModel.Entities;
public class Ville
{
    public int Id { get; set; }

    [StringLength(100)]
    public string Nom { get; set; } = string.Empty;

    //relation * * avec l'entité Aeroport
    [JsonIgnore]
    public List<Aeroport>? Aeroports { get; set; }

}
