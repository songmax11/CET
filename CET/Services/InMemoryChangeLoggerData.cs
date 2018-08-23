using CET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CET.Services
{
    public class InMemoryChangeLoggerData : IChangeLoggerData
    {
        private List<ChangeLogger> _changeLogger;

        public InMemoryChangeLoggerData()
        {
            _changeLogger = new List<ChangeLogger>();
        }
        public IEnumerable<ChangeLogger> GetAll()
        {
            return _changeLogger.OrderBy(r => r.UpdatedDate);
        }

        public List<ChangeLogger> GetChanges(object oldEntry, object newEntry)
        {
            List<ChangeLogger> logs = new List<ChangeLogger>();

            var oldType = oldEntry.GetType();
            var newType = newEntry.GetType();

            if (oldType != newType)
            {
                return logs;
            }

            var oldProperties = oldType.GetProperties();
            var newProperties = newType.GetProperties();

            var dateChanged = DateTime.Now;
            var primaryKey = (int)oldProperties
                .Where(x => Attribute.IsDefined(x, typeof(LoggingPrimaryKeyAttribute)))
                .First().GetValue(oldEntry);
            var className = oldEntry.GetType().Name;

            foreach (var oldProperty in oldProperties)
            {
                var matchingProperty = newProperties
                    .Where(x => !Attribute.IsDefined(x, typeof(IgnoreLoggingAttribute))
                        && x.Name == oldProperty.Name
                        && x.PropertyType == oldProperty.PropertyType)
                    .FirstOrDefault();

                if (matchingProperty == null)
                {
                    continue;
                }

                var oldValue = oldProperty.GetValue(oldEntry).ToString();
                var newValue = matchingProperty.GetValue(newEntry).ToString();

                if (matchingProperty != null && oldValue != newValue)
                {
                    logs.Add(new ChangeLogger()
                    {
                        Id = !_changeLogger.Any() ? 0 : _changeLogger.Max(r => r.Id) + 1,
                        PrimaryKey = primaryKey,
                        UpdatedDate = dateChanged,
                        ClassName = className,
                        PropertyName = matchingProperty.Name,
                        OldValue = oldProperty.GetValue(oldEntry).ToString(),
                        NewValue = matchingProperty.GetValue(newEntry).ToString()
                    });
                }
            }

            _changeLogger.AddRange(logs);
            return logs;
        }
    }
}
