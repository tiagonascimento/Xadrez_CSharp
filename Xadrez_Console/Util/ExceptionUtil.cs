﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez_Console.Util
{
    public class ExceptionUtil:Exception                 
    {
        public ExceptionUtil(string msg) : base(msg) { }
    }
}
