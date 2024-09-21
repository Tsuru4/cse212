using System.Collections;

// DO NOT MODIFY THIS FILE

public static class TupleListExtensionMethods
{
    public static string AsString(this IEnumerable list)
    {
        return "<List>{" + string.Join(", ", list.Cast<ValueTuple<int, int>>()) + "}";
    }
}