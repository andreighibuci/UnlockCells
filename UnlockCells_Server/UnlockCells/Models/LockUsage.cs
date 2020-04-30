using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnlockCells.Models
{
    public class LockUsage
    {
        public User User { get; set;}
        public DateTime UseLockTime { get; set; }
        
    }
}
