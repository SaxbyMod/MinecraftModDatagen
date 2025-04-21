using MinecraftModDatagen.Utils;
using MinecraftModDatagen.Versions._1214;

namespace MinecraftModDatagen.Versions
{
	public static class Release1214
	{
		public static void Datagen()
		{
			// Create and Read the CSV for the Version
			Console.WriteLine("1.21.4 Selected; Fill out the CSV added to the file directory this is executing for each item/block/etc you want to add!");
			if (!File.Exists("1.21.4.csv"))
			{
				var csv = File.CreateText("1.21.4.csv");
				csv.WriteLine("ModID, EntryName, ModelType, ModelTextureName, ItemTextureName", 0);
				csv.Close();
			}
			Console.WriteLine("File Name is 1.21.4.csv");
			Console.Write("Press any key to continue...");
			Console.ReadKey();

			// Define our Data and TODO Iteration
			List<string> todoList = new List<string>();
			Dictionary<string, DataType> data = new Dictionary<string, DataType>();

			// Get Lines from the Created CSV
			foreach (var line in File.ReadAllLines("1.21.4.csv"))
			{
				todoList.Add(line);
			}
			
			// Call our Main functions for the version
			JavaDatagen.Java_Datagen_Func(todoList);
			LanguageDatagen.Language_Datagen_Func(todoList);
			JSONDatagen.JSON_Datagen_Func(todoList, data);
		}
	}
}