using System;

namespace CET.Models
{
    public class Action
    {
        public string Attribute { get; set; }
        public int OldValue { get; set; }
        public int NewValue { get; set; }
        private DateTime CreateDate { get; set; }

        public Action(string Attribute, int OldValue, int NewValue)
        {
            this.Attribute = Attribute;
            this.OldValue = OldValue;
            this.NewValue = NewValue;
            CreateDate = DateTime.Now;
        }
    }
}
