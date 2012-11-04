﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSMine.Model
{
    public class NamedRecord : Record
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is NamedRecord)
            {
                NamedRecord comparing = (NamedRecord)obj;
                return this.Id == comparing.Id && this.Name == comparing.Name;
            }
            return false;
        }


    }
}