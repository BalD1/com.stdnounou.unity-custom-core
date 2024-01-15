
namespace StdNounou
{
	public static class StringExtensions
	{
		public static bool NotNullOrEmpty(this string s)
			=> !(s == null) && !(s.Length == 0);
	}

}