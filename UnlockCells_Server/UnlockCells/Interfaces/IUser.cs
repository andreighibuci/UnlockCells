using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnlockCells.Models;

namespace UnlockCells.Interfaces
{
    interface IUser
    {
        IEnumerable<User> Users { get;}

        User GetUserById(int userId);
    }
}
