using System.ComponentModel.DataAnnotations;

namespace AirCesiModel.Entities;
public class Personne
{
    public int Id { get; set; }

    [StringLength(100)]
    public string Nom { get; set; } = string.Empty;

    [StringLength(100)]
    public string Prenom { get; set; } = string.Empty;
}
