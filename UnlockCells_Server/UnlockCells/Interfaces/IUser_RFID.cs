using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnlockCells.Models;

namespace UnlockCells.Interfaces
{
    interface IUser_RFID
    {
        IEnumerable<User_RFID> Users_RFID { get;}

        User_RFID GetUserRFIDById(int RFID_Id);
    }
}
