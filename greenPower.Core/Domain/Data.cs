using System;
using System.Collections.Generic;
using System.Text;

namespace greenPower.Core.Domain
{
    class Data
    {
        public string Name { get; protected set; }
        public uint Address { get; protected set; }
        public float DataValue { get; protected set; }
    }
}
