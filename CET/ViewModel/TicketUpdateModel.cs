using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CET.Models.AttributesEnum;

namespace CET.ViewModel
{
    public class TicketUpdateModel
    {
        public int Id { get; set; }
        public ApplicationsEnum Application { get; set; }
        public TicketTypesEnum TicketType { get; set; }
        public UrgenciesEnum Urgency { get; set; }
        public StatusesEnum Status { get; set; }
    }
}
