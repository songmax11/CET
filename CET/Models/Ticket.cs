using System;
using System.Collections.Generic;
using static CET.Models.AttributesEnum;

namespace CET.Models
{
	public class Ticket
	{
		public ApplicationsEnum Application { get; set; }
		public StatusesEnum Status { get; set; }
		public TicketTypesEnum TicketType { get; set; }
		public UrgenciesEnum Urgency { get; set; }
		public List<Action> Actions { get; set; }
		public DateTime CreateDate { get; set; }
		public User Owner { get; set; }
		public User Submitter { get; set; }
		public int Id { get; set; }

		public void SaveActions(IEnumerable<Action> actions)
		{
			Actions.AddRange(actions);
		}
	}
}
