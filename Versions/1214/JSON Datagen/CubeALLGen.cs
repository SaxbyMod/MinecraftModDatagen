using MinecraftModDatagen.Utils;

namespace MinecraftModDatagen.Versions._1214.JSON_Datagen
{
	public class CubeALLGen
	{
		public static void GenCubeAll(DataType itemData, string entry, List<string> namespaces)
		{
			// Write the Cube_All's Blockstate
			Console.WriteLine($"Writing Block State for Cube_All called: {entry}");
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
			
			// Write the Cube_All's Blockmodels
			Console.WriteLine($"Writing Block Model(s) for Cube_All called: {entry}");
			Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/block/");
			
			// This is done for the case that each texture stems from a different mod
			if (namespaces.Count == 1)
			{
				var modelBlock = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}.json");
				modelBlock.WriteLine("{{", 0);
				modelBlock.WriteLine("  \"parent\": \"minecraft:block/cube_all\",", 1);
				modelBlock.WriteLine("  \"textures\": {{", 2);
				modelBlock.WriteLine($"    \"all\": \"{itemData.ModId}:block/{itemData.ModelTextureName}\"", 3);
				modelBlock.WriteLine("  }}", 4);
				modelBlock.WriteLine("}}", 5);
				modelBlock.Close();
			}
			else
			{
				var modelBlock = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}.json");
				modelBlock.WriteLine("{{", 0);
				modelBlock.WriteLine("  \"parent\": \"minecraft:block/cube_all\",", 1);
				modelBlock.WriteLine("  \"textures\": {{", 2);
				modelBlock.WriteLine($"    \"all\": \"{namespaces[1]}:block/{itemData.ModelTextureName}\"", 3);
				modelBlock.WriteLine("  }}", 4);
				modelBlock.WriteLine("}}", 5);
				modelBlock.Close();
			}
			
			// Say that we expect X amount of textures in X folder
			Console.WriteLine($"Expecting a file called {itemData.ModelTextureName}.png to be in textures/block");
			
			// Generate our item, the last value is true as Cube_All's have a 3d model to utilize for inventory
			BlockItemGen.GenBlockItem(itemData, entry, "Cube_All", true);
		}
	}
}