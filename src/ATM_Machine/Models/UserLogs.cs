using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_Machine.Models
{
    public class UserLogs
    {
        public UserLogs(string email, string operationType, double valueChanged, DateTime dateLog)
        {
            this.email = email;
            this.operationType = operationType;
            this.valueChanged = valueChanged;
            this.dateLog = dateLog;
        }
        public string email;
        public string operationType;
        public double valueChanged;
        public DateTime dateLog;
    }
}
