using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AirCesiModel.Entities;
public class Compagnie
{
    public int Id { get; set; }

    [StringLength(100)]
    public string Nom { get; set; } = string.Empty;

    //relation * 1 avec l'entité Vol
    [InverseProperty(nameof(Vol.Compagnie))]
    [JsonIgnore]
    public List<Vol>? Vols { get; set; }

}
