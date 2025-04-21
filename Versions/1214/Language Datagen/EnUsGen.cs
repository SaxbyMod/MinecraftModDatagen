using MinecraftModDatagen.Utils;

namespace MinecraftModDatagen.Versions._1214.Language_Datagen
{
	public class EnUsGen
	{
		public static void WriteToEnUS(int Iterator, int Iterator2, string name, string NameID, List<List<string>> guids, StreamWriter en_us)
		{
			en_us.WriteLine($"  \"block.{guids[Iterator][Iterator]}.{NameID}\": \"{name}\",", Iterator2);
			en_us.WriteLine($"  \"item.{guids[Iterator][Iterator]}.{NameID}\": \"{name}\",", Iterator2 + 1);
		}
	}
}