using MinecraftModDatagen.Utils;

namespace MinecraftModDatagen.Versions._1214.Language_Datagen
{
	public class EnUsGen
	{
		public static void WriteToEnUS(int Iterator, int Iterator2, string name, string NameID, string guid, StreamWriter en_us)
		{
			
			// Generate the en_us lines for each entry [even though item doesn't need block, we add it anyway as a way of not overcomplicating]
			en_us.WriteLine($"  \"block.{guid}.{NameID}\": \"{name}\",", Iterator2);
			en_us.WriteLine($"  \"item.{guid}.{NameID}\": \"{name}\",", Iterator2 + 1);
		}
	}
}