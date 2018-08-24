using CET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CET.ViewModel
{
    public class SearchViewModel
    {
        public IEnumerable<Ticket> Tickets { get; set; }
        public string SearchText { get; set; }
    }
}
