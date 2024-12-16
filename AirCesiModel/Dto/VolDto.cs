using AirCesiModel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCesiModel.Dto;
public class VolDto
{
    public int Id { get; set; }
    public DateTime DateDepart { get; set; }
    public DateTime DateArrivee { get; set; }
    public bool EstOuvert { get; set; }
    public string? CompagnieName { get; set; } 
    public string? AeroportDepart { get; set; } 
    public string? AeroportArrivee { get; set; } 
}
