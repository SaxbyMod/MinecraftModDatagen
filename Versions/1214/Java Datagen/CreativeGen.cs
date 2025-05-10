namespace MinecraftModDatagen.Versions._1214.Java_Datagen
{
	public class CreativeGen
	{
		public static void WriteToCreativeCubes(List<string> Name, StreamWriter CreativeTab)
		{
			string name = Name[0];
			string block = $"                output.accept(Cubes.{name.ToUpper()}.get());";
			CreativeTab.WriteLine(block);
		}
		
		public static void WriteToCreativeItems(List<string> Name, StreamWriter CreativeTab)
		{
			string name = Name[0];
			string block = $"                output.accept(Items.{name.ToUpper()}.get());";
			CreativeTab.WriteLine(block);
		}
	}
}