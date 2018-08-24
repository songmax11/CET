using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CET.Models
{
    public class ChangeLogger
    {
        public int ActionId { get; set; }
        public string ClassName { get; set; }
        public string PropertyName { get; set; }
        public int PrimaryKey { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
