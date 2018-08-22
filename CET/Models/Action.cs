using System;

namespace CET.Models
{
    public class Action
    {
		public Ticket Ticket { get; set; }
		public string Attribute { get; set; }
        public dynamic OldValue { get; set; }
        public dynamic NewValue { get; set; }
        private DateTime CreateDate { get; set; }

        public Action(string Attribute, dynamic OldValue, dynamic NewValue)
        {
            this.Attribute = Attribute;
            this.OldValue = OldValue;
            this.NewValue = NewValue;
            CreateDate = DateTime.Now;
        }
    }
}
