using System.Collections.Generic;
using System.Linq;

namespace JohnVerbiest.TransformOnBuild.MSBuild.Task
{
    public static class ObjectExtensions
    {
        public static bool IsOneOf<T>(this T obj, T[] values, IEqualityComparer<T> equalityComparer = null)
        {
            return values.Contains(obj, equalityComparer);
        }
    }
}