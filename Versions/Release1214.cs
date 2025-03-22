

using MinecraftModDatagen.Utils;

namespace MinecraftModDatagen.Versions
{
	public class Release1214
	{
		public static void Datagen()
		{
			Console.WriteLine("1.21.4 Selected; Fill out the CSV added to the file directory this is executing for each item/block/etc you want to add!");
			var csv = File.CreateText("1.21.4.csv");
			csv.WriteLine("Mod_ID, Entry name, Entry Model Type, Model Texture Name, Item Texture Name", 0);
			csv.Close();
			Console.WriteLine("File Name is 1.21.4.csv");
			Console.Write("Press any key to continue...");
			Console.ReadKey();
			// Define our Data and TODO Iteration
			List<string> TODOList = new List<string>();
			Dictionary<string, DataType> data = new Dictionary<string, DataType>();
			// Get Lines from the Created CSV
			foreach (var line in File.ReadAllLines("1.21.4.csv"))
			{
				TODOList.Add(line);
			}
			// Get Properties from CSV Lines
			foreach (var line in TODOList)
			{
				for (int i = 1; i < TODOList.Count; i++)
				{
					var section = line.Split(',');
					// Create a Object for each Section
					DataType dataType = new DataType()
					{
						ModID = section[0],
						EntryName = section[1],
						ModelType = section[2],
						ModelTextureName = section[3],
						ItemTextureName = section[4],
					};
					// Add the Object to the data
					data.Add(section[1], dataType);
				}
			}
			foreach (var item in data)
			{
				var itemData = item.Value;
				if (itemData.ModelType == "Block_Cube")
				{
					Console.WriteLine($"Writing Block State for Block Cube called: {itemData.EntryName}");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModID}/blockstates/");
					var Blockstate = File.CreateText($"Datagen/1.21.4/{itemData.ModID}/blockstates/{itemData.EntryName}.json");
					Blockstate.WriteLine("{{", 0);
					Blockstate.WriteLine("  \"variants\": {{", 1);
					Blockstate.WriteLine("    \"\": {{", 2);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}\"", 3);
					Blockstate.WriteLine("    }}", 4);
					Blockstate.WriteLine("  }}", 5);
					Blockstate.WriteLine("}}", 6);
					Blockstate.Close();
					Console.WriteLine($"Writing Block Model for Block Cube called: {itemData.EntryName}");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModID}/models/block/");
					var ModelBlock = File.CreateText($"Datagen/1.21.4/{itemData.ModID}/models/block/{itemData.EntryName}.json");
					if (itemData.ModelTextureName != "")
					{
						ModelBlock.WriteLine("{{", 0);
						ModelBlock.WriteLine("  \"parent\": \"minecraft:block/cube_all\",", 1);
						ModelBlock.WriteLine("  \"textures\": {{", 2);
						ModelBlock.WriteLine($"    \"all\": \"{itemData.ModID}:block/{itemData.ModelTextureName}\"", 3);
						ModelBlock.WriteLine("  }}", 4);
						ModelBlock.WriteLine("}}", 5);
						ModelBlock.Close();
						Console.WriteLine($"Expecting a file called {itemData.ModelTextureName}.png to be in textures/block");
					}
					else
					{
						ModelBlock.WriteLine("{{", 0);
						ModelBlock.WriteLine("  \"parent\": \"minecraft:block/cube_all\",", 1);
						ModelBlock.WriteLine("  \"textures\": {{", 2);
						ModelBlock.WriteLine($"    \"all\": \"{itemData.ModID}:block/{itemData.EntryName}\"", 3);
						ModelBlock.WriteLine("  }}", 4);
						ModelBlock.WriteLine("}}", 5);
						ModelBlock.Close();
						Console.WriteLine($"Expecting a file called {itemData.EntryName}.png to be in textures/block");
					}
					Console.WriteLine($"Writing Item for Block Cube called: {itemData.EntryName}");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModID}/items/");
					var ItemBlock = File.CreateText($"Datagen/1.21.4/{itemData.ModID}/items/{itemData.EntryName}.json");
					if (itemData.ItemTextureName == "")
					{
						ItemBlock.WriteLine("{{", 0);
						ItemBlock.WriteLine("  \"model\": {{", 1);
						ItemBlock.WriteLine("    \"type\": \"minecraft:model\",", 2);
						ItemBlock.WriteLine($"    \"model\": \"{itemData.ModID}:block/{itemData.EntryName}\"", 4);
						ItemBlock.WriteLine("  }}", 5);
						ItemBlock.WriteLine("}}", 6);
						ItemBlock.Close();
						Console.WriteLine($"Expecting a file called {itemData.EntryName}.json to be in models/block");
					}
					else
					{
						ItemBlock.WriteLine("{{", 0);
						ItemBlock.WriteLine("  \"model\": {{", 1);
						ItemBlock.WriteLine("    \"type\": \"minecraft:model\",", 2);
						ItemBlock.WriteLine($"    \"model\": \"{itemData.ModID}:item/{itemData.ItemTextureName}\"", 3);
						ItemBlock.WriteLine("  }}", 4);
						ItemBlock.WriteLine("}}", 5);
						ItemBlock.Close();
						Console.WriteLine($"Expecting a file called {itemData.ItemTextureName}.png to be in textures/item");
					}
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModID}/textures/block/");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModID}/textures/item/");
				}
			}
		}
	}
}