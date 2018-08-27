using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CET.Services
{
	public interface IGreeter
	{
		string GetWelcomeMessage();
	}

	public class Greeter : IGreeter
	{
		public string GetWelcomeMessage()
		{
			return "Welcome to Customer Engagement Tool";
		}
	}
}
