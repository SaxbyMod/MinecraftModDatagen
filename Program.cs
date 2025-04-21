using MinecraftModDatagen.Versions;

namespace MinecraftModDatagen
{
	public class MinecraftDatagen
	{
		public static void Main()
		{
			
			// Makes the App run after it finishes
			while (true)
			{
				
				// Asks for the version and sets it
				Console.WriteLine("Input a minecraft version in Major Minor Bugfix form!");
				Console.Write("Version: ");
				var version = Console.ReadLine();
				
				// Check if the versions available; really simple as I way a tad lazy; than call its data gen function
				if (version == "1.21.4")
				{
					Release1214.Datagen();
				}
			}
		}
	}
}