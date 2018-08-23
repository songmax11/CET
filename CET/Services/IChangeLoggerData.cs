using CET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CET.Services
{
    public interface IChangeLoggerData
    {
        IEnumerable<ChangeLogger> GetAll();
        List<ChangeLogger> GetChanges(object oldEntry, object newEntry);
    }
}
