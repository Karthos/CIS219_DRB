using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace BearDenFileStorage
{
    public class UserController
    {
        public string Files()
        {
            return "'username''s public files";
        }

        public string Share()
        {
            return "Files that you and 'username' are sharing with each other";
        }
    }
}
