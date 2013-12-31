using System;

namespace OpenCC.Common
{
    /// <summary>
    /// Comparable helper.
    /// </summary>
    public static class ComparableHelper
    {
        /// <summary>
        /// Compare the specified a and b.
        /// </summary>
        /// <param name="a">The alpha component.</param>
        /// <param name="b">The blue component.</param>
        /// <returns>Less than 0 if a lower than b, greater than 0 if a greater than b and 0 if both are equal</returns>
        public static int Compare<TComparable>(TComparable a, TComparable b)
            where TComparable : IComparable
        {
            int result = 0;

            if ((object)a != null)//cast to object thus overloaded != operator do not get called (avoid stack overflow)
                result = a.CompareTo(b);
            else if ((object)a == null && (object)b != null)//cast to object thus overloaded != operator do not get called (avoid stack overflow)
                result = -b.CompareTo(a);
            else
                result = 0;

            return result;
        }
    }
}

