using System;

namespace Cad.Core.Util.Guard
{
    public static class Guard
    {
        public static void IsNotNull(object obj)
        {
            if (obj == null)
                throw new ArgumentException();
            
        }
    }
}
