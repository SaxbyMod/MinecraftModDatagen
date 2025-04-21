using MinecraftModDatagen.Versions._1214.Java_Datagen;

namespace MinecraftModDatagen.Versions._1214 {
	public class JavaDatagen
	{
		public static void Java_Datagen_Func(List<string> todoList)
		{
			int Iterator = 1;
			List<List<string>> names = new List<List<string>>();
			List<List<string>> properties = new List<List<string>>();
			List<List<string>> guids = new List<List<string>>();
			// Read Lines in CSV than Java Classes
			for (Iterator = 0; Iterator < todoList.Count; Iterator++)
			{
				var Properties = todoList[Iterator].Split(',').ToList()[2].Split(';').ToList();
				var NameSpaces = todoList[Iterator].Split(',').ToList()[0].Split(';').ToList();
				var Names = todoList[Iterator].Split(',').ToList()[1].Split(';').ToList();
				properties.Add(Properties);
				guids.Add(NameSpaces);
				names.Add(Names);
			}
			// Create Our Java Classes
			for (Iterator = 0; Iterator < names.Count; Iterator++)
			{
				Directory.CreateDirectory($"Datagen/1.21.4/{guids[Iterator][Iterator]}/java/");
				var Cubes = File.CreateText($"Datagen/1.21.4/{guids[Iterator][Iterator]}/java/Cubes.java");
				int IteratorCubes = 0;
				foreach (var Property in properties)
				{
					if (Property[0] == "Cube" || Property[0] == "Cube_All")
					{
						CubesGen.WriteToCube(Property, Iterator, IteratorCubes, Cubes, names);
					}
				}
				Cubes.Close();
			}
		}
	}
}