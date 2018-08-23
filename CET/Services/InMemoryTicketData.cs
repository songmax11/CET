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
				new Ticket{ Id = 1, Application = ApplicationsEnum.TheGrid, TicketType = TicketTypesEnum.Bug, Urgency = UrgenciesEnum.Regular, Status = StatusesEnum.Defined },
				new Ticket{ Id = 2, Application = ApplicationsEnum.Approval, TicketType = TicketTypesEnum.Enhencement, Urgency = UrgenciesEnum.Critital, Status = StatusesEnum.Defined }
			};
		}

		public Ticket Add(Ticket ticket)
		{
			ticket.Id = _tickets.Max(r => r.Id) + 1;
			ticket.Status = StatusesEnum.Defined;
			ticket.CreateDate = DateTime.Now;

			_tickets.Add(ticket);
			return ticket;
		}

		public Ticket Get(int id)
		{
			return _tickets.FirstOrDefault(r => r.Id == id);
		}

		public IEnumerable<Ticket> GetAll()
		{
			return _tickets.OrderBy(r => r.CreateDate);
		}
    }
}
