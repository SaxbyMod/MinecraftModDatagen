using MinecraftModDatagen.Utils;

namespace MinecraftModDatagen.Versions._1214.JSON_Datagen
{
	public class ItemGen
	{
		public static void GenItem(DataType itemData, string entry)
		{
			// Write the Item's Item model correlator
			Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/items/");
			var itemBlock = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/items/{entry}.json");
			Console.WriteLine($"Writing Item for Item called: {entry}");
			itemBlock.WriteLine("{{", 0);
			itemBlock.WriteLine("  \"model\": {{", 1);
			itemBlock.WriteLine("    \"type\": \"minecraft:model\",", 2);
			itemBlock.WriteLine($"    \"model\": \"{itemData.ModId}:item/{entry}\"", 3);
			itemBlock.WriteLine("  }}", 4);
			itemBlock.WriteLine("}}", 5);
			itemBlock.Close();
			
			// Write the Item's Item Model
			Console.WriteLine($"Writing Item Model for Item called: {entry}");
			Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/item/");
			var itemModel = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/item/{entry}.json");
			itemModel.WriteLine("{{", 0);
			itemModel.WriteLine("  \"parent\": \"minecraft:item/generated\",", 1);
			itemModel.WriteLine("  \"textures\": {{", 2);
			itemModel.WriteLine($"    \"layer0\": \"{itemData.ModId}:item/{itemData.ItemTextureName}\"", 3);
			itemModel.WriteLine("  }}", 4);
			itemModel.WriteLine("}}", 5);
			itemModel.Close();
			
			// Say that we expect X amount of textures in X folder
			Console.WriteLine($"Expecting a file called {itemData.ItemTextureName}.png to be in textures/item");
			
			// Create the Texture Directories if they werent already existant.
			Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/textures/block/");
			Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/textures/item/");
		}
	}
}