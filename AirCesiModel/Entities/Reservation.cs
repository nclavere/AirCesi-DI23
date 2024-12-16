using System.ComponentModel.DataAnnotations.Schema;

namespace AirCesiModel.Entities;
public class Reservation
{
    public int Id { get; set; }
    public DateTime Creation { get; set; }
    public DateTime? Confirmation { get; set; }
    public DateTime? Annulation { get; set; }

    //relation 1 * avec l'entité Vol
    [ForeignKey(nameof(Vol))]
    public int VolId { get; set; }
    public Vol? Vol { get; set; }

    //relation 1 * avec l'entité Client
    [ForeignKey(nameof(Client))]
    public int ClientId { get; set; }
    public Client? Client { get; set; }

    //relation 1 * avec l'entité Passager
    [ForeignKey(nameof(Passager))]
    public int PassagerId { get; set; }
    public Passager? Passager { get; set; }
}
