using MinecraftModDatagen.Utils;

namespace MinecraftModDatagen.Versions._1214.JSON_Datagen
{
	public class ButtonGen
	{
		public static void GenButton(DataType itemData, string entry, List<string> namespaces)
		{
			// Write the Button's Blockstate
			Console.WriteLine($"Writing Block State for Button called: {entry}");
			Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/blockstates/");
			var blockstate = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/blockstates/{entry}.json");
			blockstate.WriteLine("{{", 0);
			blockstate.WriteLine("  \"variants\": {{", 1);
			blockstate.WriteLine("    \"face=ceiling,facing=east,powered=false\": {{", 2);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}\",", 3);
			blockstate.WriteLine("      \"x\": 180,", 4);
			blockstate.WriteLine("      \"y\": 270", 5);
			blockstate.WriteLine("    }},", 6);
			blockstate.WriteLine("    \"face=ceiling,facing=east,powered=true\": {{", 7);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}_pressed\",", 8);
			blockstate.WriteLine("      \"x\": 180,", 9);
			blockstate.WriteLine("      \"y\": 270", 10);
			blockstate.WriteLine("    }},", 11);
			blockstate.WriteLine("    \"face=ceiling,facing=north,powered=false\": {{", 12);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}\",", 13);
			blockstate.WriteLine("      \"x\": 180,", 14);
			blockstate.WriteLine("      \"y\": 180", 15);
			blockstate.WriteLine("    }},", 16);
			blockstate.WriteLine("    \"face=ceiling,facing=north,powered=true\": {{", 17);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}_pressed\",", 18);
			blockstate.WriteLine("      \"x\": 180,", 19);
			blockstate.WriteLine("      \"y\": 180", 20);
			blockstate.WriteLine("    }},", 21);
			blockstate.WriteLine("    \"face=ceiling,facing=south,powered=false\": {{", 22);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}\",", 23);
			blockstate.WriteLine("      \"x\": 180", 24);
			blockstate.WriteLine("    }},", 25);
			blockstate.WriteLine("    \"face=ceiling,facing=south,powered=true\": {{", 26);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}_pressed\",", 27);
			blockstate.WriteLine("      \"x\": 180", 28);
			blockstate.WriteLine("    }},", 29);
			blockstate.WriteLine("    \"face=ceiling,facing=west,powered=false\": {{", 30);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}\",", 31);
			blockstate.WriteLine("      \"x\": 180,", 32);
			blockstate.WriteLine("      \"y\": 90", 33);
			blockstate.WriteLine("    }},", 34);
			blockstate.WriteLine("    \"face=ceiling,facing=west,powered=true\": {{", 35);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}_pressed\",", 36);
			blockstate.WriteLine("      \"x\": 180,", 37);
			blockstate.WriteLine("      \"y\": 90", 38);
			blockstate.WriteLine("    }},", 39);
			blockstate.WriteLine("    \"face=floor,facing=east,powered=false\": {{", 40);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}\",", 41);
			blockstate.WriteLine("      \"y\": 90", 42);
			blockstate.WriteLine("    }},", 43);
			blockstate.WriteLine("    \"face=floor,facing=east,powered=true\": {{", 44);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}_pressed\",", 45);
			blockstate.WriteLine("      \"y\": 90", 46);
			blockstate.WriteLine("    }},", 47);
			blockstate.WriteLine("    \"face=floor,facing=north,powered=false\": {{", 48);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}\"", 49);
			blockstate.WriteLine("    }},", 50);
			blockstate.WriteLine("    \"face=floor,facing=north,powered=true\": {{", 51);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}_pressed\"", 52);
			blockstate.WriteLine("    }},", 53);
			blockstate.WriteLine("    \"face=floor,facing=south,powered=false\": {{", 54);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}\",", 55);
			blockstate.WriteLine("      \"y\": 180", 56);
			blockstate.WriteLine("    }},", 57);
			blockstate.WriteLine("    \"face=floor,facing=south,powered=true\": {{", 58);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}_pressed\",", 59);
			blockstate.WriteLine("      \"y\": 180", 60);
			blockstate.WriteLine("    }},", 61);
			blockstate.WriteLine("    \"face=floor,facing=west,powered=false\": {{", 62);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}\",", 63);
			blockstate.WriteLine("      \"y\": 270", 64);
			blockstate.WriteLine("    }},", 65);
			blockstate.WriteLine("    \"face=floor,facing=west,powered=true\": {{", 66);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}_pressed\",", 67);
			blockstate.WriteLine("      \"y\": 270", 68);
			blockstate.WriteLine("    }},", 69);
			blockstate.WriteLine("    \"face=wall,facing=east,powered=false\": {{", 70);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}\",", 71);
			blockstate.WriteLine("      \"uvlock\": true,", 72);
			blockstate.WriteLine("      \"x\": 90,", 73);
			blockstate.WriteLine("      \"y\": 90", 74);
			blockstate.WriteLine("    }},", 75);
			blockstate.WriteLine("    \"face=wall,facing=east,powered=true\": {{", 76);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}_pressed\",", 77);
			blockstate.WriteLine("      \"uvlock\": true,", 78);
			blockstate.WriteLine("      \"x\": 90,", 79);
			blockstate.WriteLine("      \"y\": 90", 80);
			blockstate.WriteLine("    }},", 81);
			blockstate.WriteLine("    \"face=wall,facing=north,powered=false\": {{", 82);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}\",", 83);
			blockstate.WriteLine("      \"uvlock\": true,", 84);
			blockstate.WriteLine("      \"x\": 90", 85);
			blockstate.WriteLine("    }},", 86);
			blockstate.WriteLine("    \"face=wall,facing=north,powered=true\": {{", 87);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}_pressed\",", 88);
			blockstate.WriteLine("      \"uvlock\": true,", 89);
			blockstate.WriteLine("      \"x\": 90", 90);
			blockstate.WriteLine("    }},", 91);
			blockstate.WriteLine("    \"face=wall,facing=south,powered=false\": {{", 92);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}\",", 93);
			blockstate.WriteLine("      \"uvlock\": true,", 94);
			blockstate.WriteLine("      \"x\": 90,", 95);
			blockstate.WriteLine("      \"y\": 180", 96);
			blockstate.WriteLine("    }},", 97);
			blockstate.WriteLine("    \"face=wall,facing=south,powered=true\": {{", 98);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}_pressed\",", 99);
			blockstate.WriteLine("      \"uvlock\": true,", 100);
			blockstate.WriteLine("      \"x\": 90,", 101);
			blockstate.WriteLine("      \"y\": 180", 102);
			blockstate.WriteLine("    }},", 103);
			blockstate.WriteLine("    \"face=wall,facing=west,powered=false\": {{", 104);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}\",", 105);
			blockstate.WriteLine("      \"uvlock\": true,", 106);
			blockstate.WriteLine("      \"x\": 90,", 107);
			blockstate.WriteLine("      \"y\": 270", 108);
			blockstate.WriteLine("    }},", 109);
			blockstate.WriteLine("    \"face=wall,facing=west,powered=true\": {{", 110);
			blockstate.WriteLine($"      \"model\": \"{itemData.ModId}:block/{entry}_pressed\",", 111);
			blockstate.WriteLine("      \"uvlock\": true,", 112);
			blockstate.WriteLine("      \"x\": 90,", 113);
			blockstate.WriteLine("      \"y\": 270", 114);
			blockstate.WriteLine("    }}", 115);
			blockstate.WriteLine("  }}", 116);
			blockstate.WriteLine("}}", 117);
			blockstate.Close();
			
			// Write the Button's blockmodels
			Console.WriteLine($"Writing Block Model(s) for Button called: {entry}");
			Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/block/");
			List<string> models = itemData.ModelTextureName.Split(';').ToList();
			
			// This is done for the case that each texture stems from a different mod
			if (namespaces.Count == 1)
			{
				var button = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}.json");
				button.WriteLine("{{", 0);
				button.WriteLine("  \"parent\": \"minecraft:block/button\",", 1);
				button.WriteLine("  \"textures\": {{", 2);
				button.WriteLine($"    \"texture\": \"{itemData.ModId}:block/{models[0]}\"", 3);
				button.WriteLine("  }}", 4);
				button.WriteLine("}}", 5);
				button.Close();
				var buttonPressed = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}_pressed.json");
				buttonPressed.WriteLine("{{", 0);
				buttonPressed.WriteLine("  \"parent\": \"minecraft:block/button_pressed\",", 1);
				buttonPressed.WriteLine("  \"textures\": {{", 2);
				buttonPressed.WriteLine($"    \"texture\": \"{itemData.ModId}:block/{models[1]}\"", 3);
				buttonPressed.WriteLine("  }}", 4);
				buttonPressed.WriteLine("}}", 5);
				buttonPressed.Close();
				var buttonInventory = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}_inventory.json");
				buttonInventory.WriteLine("{{", 0);
				buttonInventory.WriteLine("  \"parent\": \"minecraft:block/button_inventory\",", 1);
				buttonInventory.WriteLine("  \"textures\": {{", 2);
				buttonInventory.WriteLine($"    \"texture\": \"{itemData.ModId}:block/{models[2]}\"", 3);
				buttonInventory.WriteLine("  }}", 4);
				buttonInventory.WriteLine("}}", 5);
				buttonInventory.Close();
			}
			else
			{
				var button = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}.json");
				button.WriteLine("{{", 0);
				button.WriteLine("  \"parent\": \"minecraft:block/button\",", 1);
				button.WriteLine("  \"textures\": {{", 2);
				button.WriteLine($"    \"texture\": \"{namespaces[1]}:block/{models[0]}\"", 3);
				button.WriteLine("  }}", 4);
				button.WriteLine("}}", 5);
				button.Close();
				var buttonPressed = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}_pressed.json");
				buttonPressed.WriteLine("{{", 0);
				buttonPressed.WriteLine("  \"parent\": \"minecraft:block/button_pressed\",", 1);
				buttonPressed.WriteLine("  \"textures\": {{", 2);
				buttonPressed.WriteLine($"    \"texture\": \"{namespaces[2]}:block/{models[1]}\"", 3);
				buttonPressed.WriteLine("  }}", 4);
				buttonPressed.WriteLine("}}", 5);
				buttonPressed.Close();
				var buttonInventory = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}_inventory.json");
				buttonInventory.WriteLine("{{", 0);
				buttonInventory.WriteLine("  \"parent\": \"minecraft:block/button_inventory\",", 1);
				buttonInventory.WriteLine("  \"textures\": {{", 2);
				buttonInventory.WriteLine($"    \"texture\": \"{namespaces[3]}:block/{models[2]}\"", 3);
				buttonInventory.WriteLine("  }}", 4);
				buttonInventory.WriteLine("}}", 5);
				buttonInventory.Close();
			}
			
			// Say that we expect X amount of textures in X folder
			Console.WriteLine($"Expecting a file called {models[0]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[1]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[2]}.png to be in textures/block");
			
			// Generate our item, the last value is true as Button's have a 3d model to utilize for inventory
			BlockItemGen.GenBlockItem(itemData, entry, "Button", true);
		}
	}
}