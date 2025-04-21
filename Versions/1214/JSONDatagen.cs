using MinecraftModDatagen.Utils;
using MinecraftModDatagen.Versions._1214.JSON_Datagen;

namespace MinecraftModDatagen.Versions._1214 {
public class JSONDatagen
{
	public static void JSON_Datagen_Func(List<string> todoList, Dictionary<string, DataType> data)
	{
			// Get Properties from CSV Lines
			foreach (var line in todoList)
			{
				// Skip the header lien
				if (line == "ModID, EntryName, ModelType, ModelTextureName, ItemTextureName")
				{
					Console.WriteLine($"Skipping unnened line");
					continue;
				}
				
				// Split the line into sections
				var section = line.Split(',');
				
				// Define our entry's name [Important for all datagens]
				var entryName = section[1];
				
				// Skip over any duplicated entrys
				if (data.ContainsKey(entryName))
				{
					Console.WriteLine($"Duplicate EntryName found: {entryName}, skipping this entry.");
					continue;
				}
				
				// Create an Object for each Section.
				DataType dataType = new DataType()
				{
					ModId = section[0],
					EntryName = section[1],
					ModelType = section[2],
					ModelTextureName = section[3],
					ItemTextureName = section[4],
				};
				
				// Add the Object to the data
				data.Add(dataType.EntryName, dataType);
			}

			// Read Lines in CSV than Datagen
			foreach (var item in data)
			{
				
				// Define our basic values [Item Data object, Entry, ModID; In specific the one used in jsons rather than the mods identifier, and set the model type to the base type in the case that there are multiple; ex Java Datagen requires it to be split]
				Console.WriteLine($"Datagenning for {item.Key}");
				var itemData = item.Value;
				List<string> EntryNames = itemData.EntryName.Split(';').ToList();
				var entry = EntryNames[0];
				List<string> namespaces = itemData.ModId.Split(';').ToList();
				itemData.ModId = namespaces[0];
				List<string> Properties = itemData.ModelType.Split(';').ToList();
				itemData.ModelType = Properties[0];
				
				// Check our type and do gen from its class
				if (itemData.ModelType == "Cube_All")
				{
					CubeALLGen.GenCubeAll(itemData, entry, namespaces);
				}
				if (itemData.ModelType == "Cube")
				{
					CubeGen.GenCube(itemData, entry, namespaces);
				}
				if (itemData.ModelType == "Button")
				{
					ButtonGen.GenButton(itemData, entry, namespaces);
				}
				if (itemData.ModelType == "Slab")
				{
					SlabGen.GenSlab(itemData, entry, namespaces);
				}
				if (itemData.ModelType == "Stair")
				{
					StairGen.GenStair(itemData, entry, namespaces);
				}
				if (itemData.ModelType == "Lever")
				{
					LeverGen.GenLever(itemData, entry, namespaces);
				}
				if (itemData.ModelType == "Item")
				{
					ItemGen.GenItem(itemData, entry);
				}
				
				// State that we finished data gen for X item.
				Console.WriteLine($"Finished datagenning for {item.Key}");
			}
	}
}
}