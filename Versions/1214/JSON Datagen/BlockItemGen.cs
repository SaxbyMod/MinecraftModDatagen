using MinecraftModDatagen.Utils;

namespace MinecraftModDatagen.Versions._1214.JSON_Datagen
{
	public class BlockItemGen
	{
		public static void GenBlockItem(DataType itemData, string entry, string type, bool hasItemTextureNameOptional)
		{
			// Setup for the Base itemBlock json
			Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/items/");
			var itemBlock = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/items/{entry}.json");
			
			// This is done for the case that a item doesn't have a 3d model which can be used in inventory.
			if (hasItemTextureNameOptional == true)
			{
				
				// This is done to determine whether the Item Texture is defined and if it is, than we use a more advanced system.
				if (itemData.ItemTextureName == "")
				{
					
					// This is done to ensure that the Button model is tied to the correct model.
					if (type != "Button")
					{
						// Write the Block Item for Non-Button's
						Console.WriteLine($"Writing Item for {type} called: {entry}");
						itemBlock.WriteLine("{{", 0);
						itemBlock.WriteLine("  \"model\": {{", 1);
						itemBlock.WriteLine("    \"type\": \"minecraft:model\",", 2);
						itemBlock.WriteLine($"    \"model\": \"{itemData.ModId}:block/{entry}\"", 4);
						itemBlock.WriteLine("  }}", 5);
						itemBlock.WriteLine("}}", 6);
						itemBlock.Close();
					}
					else
					{
						// Write the Block Item for Button's
						Console.WriteLine($"Writing Item for {type} called: {entry}");
						itemBlock.WriteLine("{{", 0);
						itemBlock.WriteLine("  \"model\": {{", 1);
						itemBlock.WriteLine("    \"type\": \"minecraft:model\",", 2);
						itemBlock.WriteLine($"    \"model\": \"{itemData.ModId}:block/{entry}_inventory\"", 4);
						itemBlock.WriteLine("  }}", 5);
						itemBlock.WriteLine("}}", 6);
						itemBlock.Close();
					}
				}
				else
				{
					// Write the Block Item with the Advanced system.
					Console.WriteLine($"Writing Item for {type} called: {entry}");
					itemBlock.WriteLine("{{", 0);
					itemBlock.WriteLine("  \"model\": {{", 1);
					itemBlock.WriteLine("    \"type\": \"minecraft:model\",", 2);
					itemBlock.WriteLine($"    \"model\": \"{itemData.ModId}:item/{entry}\"", 3);
					itemBlock.WriteLine("  }}", 4);
					itemBlock.WriteLine("}}", 5);
					itemBlock.Close();
					
					// Write the Item Model
					Console.WriteLine($"Writing Item Model for {type} called: {entry}");
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
				}
			}
			else
			{
				// Write the Block Item for Types that don't have a 3d Model
				Console.WriteLine($"Writing Item for {type} called: {entry}");
				itemBlock.WriteLine("{{", 0);
				itemBlock.WriteLine("  \"model\": {{", 1);
				itemBlock.WriteLine("    \"type\": \"minecraft:model\",", 2);
				itemBlock.WriteLine($"    \"model\": \"{itemData.ModId}:item/{entry}\"", 3);
				itemBlock.WriteLine("  }}", 4);
				itemBlock.WriteLine("}}", 5);
				itemBlock.Close();
				
				// Write the Item Model for types that don't have a 3d Model
				Console.WriteLine($"Writing Item Model for {type} called: {entry}");
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
			}
			
			// Create the Texture Directories if they werent already existant.
			Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/textures/block/");
			Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/textures/item/");
		}
	}
}