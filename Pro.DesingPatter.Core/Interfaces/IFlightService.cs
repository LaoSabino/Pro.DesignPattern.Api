using Pro.DesingPatter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.DesingPatter.Core.Interfaces;

public interface IFlightService { List<Flight> GetFlights(string origin, string destination); }
