using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CET.Models.AttributesEnum;

namespace CET.ViewModel
{
	public class TicketCreateModel
	{
		public ApplicationsEnum App { get; set; }
		public TicketTypesEnum Type { get; set; }
		public UrgenciesEnum Urgency { get; set; }
	}
}
