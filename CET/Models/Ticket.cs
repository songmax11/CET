using System;
using System.Collections.Generic;
using static CET.Models.AttributesEnum;

namespace CET.Models
{
    public class Ticket
    {
        private ApplicationsEnum Application { get; set; }
        private StatusesEnum Status { get; set; }
        private TicketTypesEnum TicketType { get; set; }
        private UrgenciesEnum Urgency { get; set; }
        private List<Action> Actions { get; set; }
        private DateTime CreateDate { get; set; }

        public Ticket(ApplicationsEnum Application, TicketTypesEnum TicketType, UrgenciesEnum Urgency)
        {
            this.Application = Application;
            this.TicketType = TicketType;
            this.Urgency = Urgency;
            Status = StatusesEnum.Defined;
            CreateDate = DateTime.Now;
        }

        public void SaveActions(IEnumerable<Action> actions)
        {
            Actions.AddRange(actions);
        }
    }
}
