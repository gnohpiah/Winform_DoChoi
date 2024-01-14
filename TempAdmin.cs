using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoChoi
{
    //Last update: 11/01/2023
    internal class TempAdmin
    {
        private static bool _isAdmin;
        public static bool IsAdmin { get => _isAdmin; set => _isAdmin = value; }
    }
}
