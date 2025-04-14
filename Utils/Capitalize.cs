namespace MinecraftModDatagen.Utils
{
	public static class CapitalizeFuncs
	{
		// Stack Overflow - javadch
		public static string Capitalize(this string word)
		{
			return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
		}
		// Provided by GPT
		public static string CapitalizeWithSpaces(this string sentence)
		{
			string[] words = sentence.Split(' ');
			for (int i = 0; i < words.Length; i++)
			{
				words[i] = words[i].Capitalize();
			}

			return string.Join(" ", words);
		}
	}
}