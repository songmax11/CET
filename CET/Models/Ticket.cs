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
		public string Description { get; set; }
		//public User Owner { get; set; }
		//public User Submitter { get; set; }
		[IgnoreLogging]
		public DateTime CreateDate { get; set; }
		[LoggingPrimaryKey]
		public int Id { get; set; }

		internal Ticket Clone()
		{
			var res = new Ticket
			{
				Id = Id,
				Application = Application,
				Status = Status,
				TicketType = TicketType,
				Urgency = Urgency,
				CreateDate = CreateDate
			};

			return res;
		}
	}
}
