using MinecraftModDatagen.Versions;

namespace MinecraftModDatagen
{
	public class MinecraftDatagen
	{
		public static void Main()
		{
			while (true)
			{
				Console.WriteLine("Input a minecraft version in Major Minor Bugfix form!");
				Console.Write("Version: ");
				var version = Console.ReadLine();
				if (version == "1.21.4")
				{
					Release1214.Datagen();
				}
			}
		}
	}
}