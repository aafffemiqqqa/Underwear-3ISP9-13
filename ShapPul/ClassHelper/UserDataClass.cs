using ShapPul.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.ClassHelper
{
    public class UserDataClass
    {
        public static Account User { get; set; }

        public static Employee Employee { get; set; }

        public static Client Client { get; set; }
    }
}