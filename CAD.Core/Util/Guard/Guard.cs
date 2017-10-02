using System;

namespace CAD.Core.Util.Guard
{
    public static class Guard
    {
        public static void IsNotNull(object obj, string memberName = "")
        {
            if (obj == null)
                throw new ArgumentException(memberName);
            
        }
    }
}
