using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnlockCells.Models
{
    public class User
    {
        public string Name{ get; set; }

        public int Id { get; set; }

        public string Department { get; set; }

        public int PhoneNumber { get; set; }

        public string urlToPhoto { get; set; }

        public virtual User_RFID User_RFID { get; set; }
    }
}
