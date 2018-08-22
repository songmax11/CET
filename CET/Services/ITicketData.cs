using CET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CET.Services
{
    public interface ITicketData
    {
		IEnumerable<Ticket> GetAll();
    }
}
