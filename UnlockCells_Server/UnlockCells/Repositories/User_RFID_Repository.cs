using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnlockCells.Interfaces;
using UnlockCells.Models;

namespace UnlockCells.Repositories
{
    public class User_RFID_Repository : IUser_RFID
    {
        private readonly AppDbContext _appDbContext;
        public User_RFID_Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<User_RFID> Users_RFID => _appDbContext.Users_RFID;

        public User_RFID GetUserRFIDById(int RFID_Id) => _appDbContext.Users_RFID.FirstOrDefault(p => p.Id == RFID_Id);

    }
}
