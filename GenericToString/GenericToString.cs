using System.Collections;
using System.Collections.Generic;

namespace GenericToString
{
    public static class GenericToString
    {
        public static string ToString<T>(this List<T> list) => "{" + string.Join(", ", list.ToArray()) + "}";
        public static string ToString<T>(this ArrayList list) => "{" + string.Join(", ", list.ToArray()) + "}";

    }
}
