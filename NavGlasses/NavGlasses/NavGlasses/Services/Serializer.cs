using System;
using System.Collections.Generic;
using System.Text;

namespace NavGlasses.Services
{
    public static class Serializer
    {
        public static byte Serialize(int data)
        {
            return Convert.ToByte(data);
        }
    }
}
