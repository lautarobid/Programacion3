using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Trip
{
    public int IdTrip { get; set; }
    public required string Origin { get; set; }
    public required string Destination { get; set; }
    public float Cost { get; set; }
    public DateTime DepartureDate { get; set; }
}