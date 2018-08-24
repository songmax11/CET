using CET.Models;
using CET.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static CET.Models.AttributesEnum;

namespace CET.Services
{
	public class InMemoryTicketData : ITicketData
	{
		List<Ticket> _tickets;
		private readonly IChangeLoggerData _changeLoggerData;

		public InMemoryTicketData(IChangeLoggerData changeLoggerData)
		{
			_changeLoggerData = changeLoggerData;
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

		public void Update(TicketUpdateModel model)
		{
			Ticket updatingTicket = _tickets.FirstOrDefault(r => r.Id == model.Id);
			Ticket oldTicket = updatingTicket.Clone();

			updatingTicket.Application = model.Application;
			updatingTicket.Urgency = model.Urgency;
			updatingTicket.TicketType = model.TicketType;
			updatingTicket.Status = model.Status;

			_changeLoggerData.GetChanges(oldTicket, updatingTicket);
		}

		public IEnumerable<Ticket> Search(string searchText)
		{
			List<Ticket> filteredResult = new List<Ticket>();
			string[] filters = searchText.Split(' ');
			foreach (Ticket t in _tickets)
			{
				bool isMatch = false;
				foreach (string f in filters)
				{
					isMatch = t.GetType().GetProperties()
				   .Select(pi => pi.GetValue(t).ToString())
				   .Any(value => value.ToLower().Contains(f.ToLower()));
				}

				if (isMatch)
				{
					filteredResult.Add(t);
				}
			}

			return filteredResult;
		}
	}
}
