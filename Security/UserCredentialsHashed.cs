﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public class UserPasswordHashed
    {       
        public string HashedPassword { get; set; }
        public string PasswordSalt { get; set; }
    }
}
