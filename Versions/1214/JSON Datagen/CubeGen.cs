using MinecraftModDatagen.Utils;

namespace MinecraftModDatagen.Versions._1214.JSON_Datagen
{
	public class CubeGen
	{
		public static void GenCube(DataType itemData, string entry, List<string> namespaces)
		{
			// Write the Cube's Blockstate
			Console.WriteLine($"Writing Block State for Cube called: {entry}");
			Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/blockstates/");
			var blockstate = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/blockstates/{entry}.json");
			blockstate.WriteLine("{{", 0);
			blockstate.WriteLine("  \"variants\": {{", 1);
			blockstate.WriteLine("    \"\": {{", 2);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}\"", 3);
			blockstate.WriteLine("    }}", 4);
			blockstate.WriteLine("  }}", 5);
			blockstate.WriteLine("}}", 6);
			blockstate.Close();
			
			// Write the Cube's Blockmodels
			Console.WriteLine($"Writing Block Model(s) for Cube called: {entry}");
			Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/block/");
			List<string> models = itemData.ModelTextureName.Split(';').ToList();
			
			// This is done for the case that each texture stems from a different mod
			if (namespaces.Count == 1)
			{
				var modelBlock = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}.json");
				modelBlock.WriteLine("{{", 0);
				modelBlock.WriteLine("  \"parent\": \"block/cube\",", 1);
				modelBlock.WriteLine("  \"textures\": {{", 2);
				modelBlock.WriteLine($"    \"down\": \"{itemData.ModId}:block/{models[0]}\",", 3);
				modelBlock.WriteLine($"    \"up\": \"{itemData.ModId}:block/{models[1]}\",", 4);
				modelBlock.WriteLine($"    \"north\": \"{itemData.ModId}:block/{models[2]}\",", 5);
				modelBlock.WriteLine($"    \"east\": \"{itemData.ModId}:block/{models[3]}\",", 6);
				modelBlock.WriteLine($"    \"south\": \"{itemData.ModId}:block/{models[4]}\",", 7);
				modelBlock.WriteLine($"    \"west\": \"{itemData.ModId}:block/{models[5]}\"", 8);
				modelBlock.WriteLine("  }}", 9);
				modelBlock.WriteLine("}}", 10);
				modelBlock.Close();
			}
			else
			{
				var modelBlock = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}.json");
				modelBlock.WriteLine("{{", 0);
				modelBlock.WriteLine("  \"parent\": \"block/cube\",", 1);
				modelBlock.WriteLine("  \"textures\": {{", 2);
				modelBlock.WriteLine($"    \"down\": \"{namespaces[1]}:block/{models[0]}\",", 3);
				modelBlock.WriteLine($"    \"up\": \"{namespaces[2]}:block/{models[1]}\",", 4);
				modelBlock.WriteLine($"    \"north\": \"{namespaces[3]}:block/{models[2]}\",", 5);
				modelBlock.WriteLine($"    \"east\": \"{namespaces[4]}:block/{models[3]}\",", 6);
				modelBlock.WriteLine($"    \"south\": \"{namespaces[5]}:block/{models[4]}\",", 7);
				modelBlock.WriteLine($"    \"west\": \"{namespaces[6]}:block/{models[5]}\"", 8);
				modelBlock.WriteLine("  }}", 9);
				modelBlock.WriteLine("}}", 10);
				modelBlock.Close();
			}
			
			// Say that we expect X amount of textures in X folder
			Console.WriteLine($"Expecting a file called {models[0]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[1]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[2]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[3]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[4]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[5]}.png to be in textures/block");
			
			// Generate our item, the last value is true as Cube's have a 3d model to utilize for inventory
			BlockItemGen.GenBlockItem(itemData, entry, "Cube", true);
		}
	}
}