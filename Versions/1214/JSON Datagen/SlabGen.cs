using MinecraftModDatagen.Utils;

namespace MinecraftModDatagen.Versions._1214.JSON_Datagen
{
	public class SlabGen
	{
		public static void GenSlab(DataType itemData, string entry, List<string> namespaces)
		{
			// Write the Slab's Blockstate
			Console.WriteLine($"Writing Block State for Slab called: {entry}");
			Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/blockstates/");
			var blockstate = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/blockstates/{entry}.json");
			blockstate.WriteLine("{{", 0);
			blockstate.WriteLine("  \"variants\": {{", 1);
			blockstate.WriteLine("    \"type=bottom\": {{", 2);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}\"", 3);
			blockstate.WriteLine("    }},", 4);
			blockstate.WriteLine("    \"type=double\": {{", 5);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}_double\"", 6);
			blockstate.WriteLine("    }},", 7);
			blockstate.WriteLine("    \"type=top\": {{", 8);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}_top\"", 9);
			blockstate.WriteLine("    }}", 10);
			blockstate.WriteLine("  }}", 11);
			blockstate.WriteLine("}}", 12);
			blockstate.Close();
			
			// Write the Slab's Blockmodels
			Console.WriteLine($"Writing Block Model(s) for Slab called: {entry}");
			Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/block/");
			List<string> models = itemData.ModelTextureName.Split(';').ToList();
			
			// This is done for the case that each texture stems from a different mod
			if (namespaces.Count == 1)
			{
				var slab = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}.json");
				slab.WriteLine("{{", 0);
				slab.WriteLine("  \"parent\": \"minecraft:block/slab\",", 1);
				slab.WriteLine("  \"textures\": {{", 2);
				slab.WriteLine($"    \"bottom\": \"{itemData.ModId}:block/{models[0]}\",", 3);
				slab.WriteLine($"    \"side\": \"{itemData.ModId}:block/{models[1]}\",", 4);
				slab.WriteLine($"    \"top\": \"{itemData.ModId}:block/{models[2]}\"", 5);
				slab.WriteLine("  }}", 6);
				slab.WriteLine("}}", 7);
				slab.Close();
				var slabDouble = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}_double.json");
				slabDouble.WriteLine("{{", 0);
				slabDouble.WriteLine("  \"parent\": \"block/cube\",", 1);
				slabDouble.WriteLine("  \"textures\": {{", 2);
				slabDouble.WriteLine($"    \"down\": \"{itemData.ModId}:block/{models[3]}\",", 3);
				slabDouble.WriteLine($"    \"up\": \"{itemData.ModId}:block/{models[4]}\",", 4);
				slabDouble.WriteLine($"    \"north\": \"{itemData.ModId}:block/{models[5]}\",", 5);
				slabDouble.WriteLine($"    \"east\": \"{itemData.ModId}:block/{models[6]}\",", 6);
				slabDouble.WriteLine($"    \"south\": \"{itemData.ModId}:block/{models[7]}\",", 7);
				slabDouble.WriteLine($"    \"west\": \"{itemData.ModId}:block/{models[8]}\"", 8);
				slabDouble.WriteLine("  }}", 9);
				slabDouble.WriteLine("}}", 10);
				slabDouble.Close();
				var slabTop = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}_top.json");
				slabTop.WriteLine("{{", 0);
				slabTop.WriteLine("  \"parent\": \"minecraft:block/slab_top\",", 1);
				slabTop.WriteLine("  \"textures\": {{", 2);
				slabTop.WriteLine($"    \"bottom\": \"{itemData.ModId}:block/{models[9]}\",", 3);
				slabTop.WriteLine($"    \"side\": \"{itemData.ModId}:block/{models[10]}\",", 4);
				slabTop.WriteLine($"    \"top\": \"{itemData.ModId}:block/{models[11]}\"", 5);
				slabTop.WriteLine("  }}", 6);
				slabTop.WriteLine("}}", 7);
				slabTop.Close();
			}
			else
			{
				var slab = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}.json");
				slab.WriteLine("{{", 0);
				slab.WriteLine("  \"parent\": \"minecraft:block/slab\",", 1);
				slab.WriteLine("  \"textures\": {{", 2);
				slab.WriteLine($"    \"bottom\": \"{namespaces[1]}:block/{models[0]}\",", 3);
				slab.WriteLine($"    \"side\": \"{namespaces[2]}:block/{models[1]}\",", 4);
				slab.WriteLine($"    \"top\": \"{namespaces[3]}:block/{models[2]}\"", 5);
				slab.WriteLine("  }}", 6);
				slab.WriteLine("}}", 7);
				slab.Close();
				var slabDouble = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}_double.json");
				slabDouble.WriteLine("{{", 0);
				slabDouble.WriteLine("  \"parent\": \"block/cube\",", 1);
				slabDouble.WriteLine("  \"textures\": {{", 2);
				slabDouble.WriteLine($"    \"down\": \"{namespaces[4]}:block/{models[3]}\",", 3);
				slabDouble.WriteLine($"    \"up\": \"{namespaces[5]}:block/{models[4]}\",", 4);
				slabDouble.WriteLine($"    \"north\": \"{namespaces[6]}:block/{models[5]}\",", 5);
				slabDouble.WriteLine($"    \"east\": \"{namespaces[7]}:block/{models[6]}\",", 6);
				slabDouble.WriteLine($"    \"south\": \"{namespaces[8]}:block/{models[7]}\",", 7);
				slabDouble.WriteLine($"    \"west\": \"{namespaces[9]}:block/{models[8]}\"", 8);
				slabDouble.WriteLine("  }}", 9);
				slabDouble.WriteLine("}}", 10);
				slabDouble.Close();
				var slabTop = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}_top.json");
				slabTop.WriteLine("{{", 0);
				slabTop.WriteLine("  \"parent\": \"minecraft:block/slab_top\",", 1);
				slabTop.WriteLine("  \"textures\": {{", 2);
				slabTop.WriteLine($"    \"bottom\": \"{namespaces[10]}:block/{models[9]}\",", 3);
				slabTop.WriteLine($"    \"side\": \"{namespaces[11]}:block/{models[10]}\",", 4);
				slabTop.WriteLine($"    \"top\": \"{namespaces[12]}:block/{models[11]}\"", 5);
				slabTop.WriteLine("  }}", 6);
				slabTop.WriteLine("}}", 7);
				slabTop.Close();
			}
			
			// Say that we expect X amount of textures in X folder
			Console.WriteLine($"Expecting a file called {models[0]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[1]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[2]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[3]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[4]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[5]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[6]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[7]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[8]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[9]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[10]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[11]}.png to be in textures/block");
			
			// Generate our item, the last value is true as Slab's have a 3d model to utilize for inventory
			BlockItemGen.GenBlockItem(itemData, entry, "Slab", true);
		}
	}
}