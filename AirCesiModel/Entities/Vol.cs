using System.ComponentModel.DataAnnotations.Schema;

namespace AirCesiModel.Entities;
public class Vol
{
    public int Id { get; set; }
    public DateTime DateDepart { get; set; }
    public DateTime DateArrivee { get; set; }
    public bool EstOuvert { get; set; }

    //relation 1 * avec l'entité Compagnie
    [ForeignKey(nameof(Compagnie))]
    public int CompagnieId { get; set; }
    public Compagnie? Compagnie { get; set; }

    //relation 1 * avec l'entité Aeroport de départ
    [ForeignKey(nameof(AeroportDepart))]
    public int AeroportDepartId { get; set; }
    public Aeroport? AeroportDepart { get; set; }

    //relation 1 * avec l'entité Aeroport d'arrivée
    [ForeignKey(nameof(AeroportArrivee))]
    public int AeroportArriveeId { get; set; }
    public Aeroport? AeroportArrivee { get; set; }

    //relation * 1 avec l'entité Reservation
    [InverseProperty(nameof(Reservation.Vol))]
    public List<Reservation>? Reservations { get; set; }

    //relation * 1 avec l'entité Vol (escales)
    public List<Vol>? Escales { get; set; }


}
