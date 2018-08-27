using CET.Models;
using CET.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CET.ViewModel
{
	public class ChangeLoggerHistory
	{
		public IEnumerable<ChangeLogger> ChangeLoggers { get; set; }
	}
}
