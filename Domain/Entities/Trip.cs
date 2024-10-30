using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Trip
{
    [Key]
    public int IdTrip { get; set; }
    public required string Origin { get; set; }
    public required string Destination { get; set; }
    public float Cost { get; set; }
    public DateTime DepartureDate { get; set; }
}