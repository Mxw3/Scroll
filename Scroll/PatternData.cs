using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scroll
{
    internal class PatternData
    {
        public bool[] Pattern = new bool[]
            {
                // J
                true,false,false,false,false,true,false,
                true,true,true,true,true,true,false,
                true,false,false,false,false,false,false,
                // e
                false,true,true,true,true,true,false,
                false,true,false,true,false,true,false,
                false,true,true,true,false,true,false,
                // blank
                false,false,false,false,false,false,false,
                // s
                false,true,true,true,false,true,false,
                false,true,false,true,true,true,false,
                // blank
                false,false,false,false,false,false,false,
                // u
                false,true,true,true,true,false,false,
                false,false,false,false,false,true,false,
                // blank
                false,false,false,false,false,false,false,
                // s
                false,true,true,true,false,true,false,
                false,true,false,true,true,true,false,
                // double blank
                false,false,false,false,false,false,false,
                false,false,false,false,false,false,false,
                // i
                true,false,true,true,true,true,false,
                // blank
                false,false,false,false,false,false,false,
                // s
                false,true,true,true,false,true,false,
                false,true,false,true,true,true,false,
                // double blank
                false,false,false,false,false,false,false,
                false,false,false,false,false,false,false,
                // L
                true,true,true,true,true,true,false,
                false,false,false,false,false,true,false,
                false,false,false,false,false,true,false,
                // blank
                false,false,false,false,false,false,false,
                // o
                false,true,true,true,true,true,false,
                false,true,false,false,false,true,false,
                false,true,true,true,true,true,false,
                // blank
                false,false,false,false,false,false,false,
                // r
                false,true,true,true,true,true,false,
                false,false,true,false,false,false,false,
                false,true,false,false,false,false,false,
                // d
                false,false,false,true,true,true,false,
                false,false,false,true,false,true,false,
                true,true,true,true,true,true,false,
                // double blank
                false,false,false,false,false,false,false,
                false,false,false,false,false,false,false,
            };
    }
}
