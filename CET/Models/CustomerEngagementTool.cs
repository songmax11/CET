using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using static CET.Models.AttributesEnum;

namespace CET.Models
{
	public class CustomerEngagementTool
	{
		private List<Ticket> Tickets { get; set; }

		public IEnumerable<Ticket> SearchTicket(string filter)
		{
			List<Ticket> filteredResult = new List<Ticket>();
			string[] filters = filter.Split(' ');
			foreach (Ticket t in Tickets)
			{
				bool isMatch = false;
				foreach (string f in filters)
				{
					isMatch = t.GetType().GetProperties()
				   .Where(pi => pi.GetValue(t) is string)
				   .Select(pi => (string)pi.GetValue(t))
				   .Any(value => value.Contains(f));
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
