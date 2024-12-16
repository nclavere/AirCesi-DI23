using System.ComponentModel.DataAnnotations;

namespace AirCesiModel.Entities;
public class Passager : Personne
{
    [StringLength(20)]
    public string? Passeport { get; set; }
}
