using CET.Models;
using CET.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CET.Services
{
	public interface ITicketData
	{
		IEnumerable<Ticket> GetAll();
		Ticket Get(int id);
		Ticket Add(Ticket ticket);
		void Update(TicketUpdateModel model);
		IEnumerable<Ticket> Search(string searchText);
	}
}
