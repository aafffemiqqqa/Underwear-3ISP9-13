using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapPul.DB;

namespace ShapPul.ClassHelper
{
    class EFClass
    {
        public static DB.Entities1 Context { get; } = new DB.Entities1();
    }
}
