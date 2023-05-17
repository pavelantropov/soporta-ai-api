namespace SoportaAI.Utils.Extensions;

public static class GenericExtensions
{
	public static bool IsIn<T>(this T value, params T[] values) => values.Contains(value);
}