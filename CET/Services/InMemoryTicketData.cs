using CET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CET.Models.AttributesEnum;

namespace CET.Services
{
    public class InMemoryTicketData : ITicketData
    {
		List<Ticket> _tickets;
		public InMemoryTicketData()
		{
			_tickets = new List<Ticket>
			{
				new Ticket(1, ApplicationsEnum.TheGrid, TicketTypesEnum.Bug, UrgenciesEnum.Regular),
				new Ticket(2, ApplicationsEnum.Sirfis, TicketTypesEnum.Enhencement, UrgenciesEnum.Critital)
			};
		}

		public IEnumerable<Ticket> GetAll()
		{
			return _tickets.OrderBy(r => r.CreateDate);
		}
    }
}
