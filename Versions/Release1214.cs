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
				if (itemData.ModelType == "Cube_All")
				{
					Console.WriteLine($"Writing Block State for Cube_All called: {itemData.EntryName}");
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
					Console.WriteLine($"Writing Block Model for Cube_All called: {itemData.EntryName}");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModID}/models/block/");
					var ModelBlock = File.CreateText($"Datagen/1.21.4/{itemData.ModID}/models/block/{itemData.EntryName}.json");
					ModelBlock.WriteLine("{{", 0);
					ModelBlock.WriteLine("  \"parent\": \"minecraft:block/cube_all\",", 1);
					ModelBlock.WriteLine("  \"textures\": {{", 2);
					ModelBlock.WriteLine($"    \"all\": \"{itemData.ModID}:block/{itemData.ModelTextureName}\"", 3);
					ModelBlock.WriteLine("  }}", 4);
					ModelBlock.WriteLine("}}", 5);
					ModelBlock.Close();
					Console.WriteLine($"Expecting a file called {itemData.ModelTextureName}.png to be in textures/block");
					Console.WriteLine($"Writing Item for Cube_All called: {itemData.EntryName}");
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
				if (itemData.ModelType == "Cube")
				{
					Console.WriteLine($"Writing Block State for Cube called: {itemData.EntryName}");
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
					Console.WriteLine($"Writing Block Model for Cube called: {itemData.EntryName}");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModID}/models/block/");
					List<string> models = itemData.ModelTextureName.Split(';').ToList();
					var ModelBlock = File.CreateText($"Datagen/1.21.4/{itemData.ModID}/models/block/{itemData.EntryName}.json");
					ModelBlock.WriteLine("{{", 0);
					ModelBlock.WriteLine("  \"parent\": \"block/cube\",", 1);
					ModelBlock.WriteLine("  \"textures\": {{", 2);
					ModelBlock.WriteLine($"    \"down\": \"{itemData.ModID}:block/{models[0]}\",", 3);
					ModelBlock.WriteLine($"    \"up\": \"{itemData.ModID}:block/{models[1]}\",", 4);
					ModelBlock.WriteLine($"    \"north\": \"{itemData.ModID}:block/{models[2]}\",", 5);
					ModelBlock.WriteLine($"    \"east\": \"{itemData.ModID}:block/{models[3]}\",", 6);
					ModelBlock.WriteLine($"    \"south\": \"{itemData.ModID}:block/{models[4]}\",", 7);
					ModelBlock.WriteLine($"    \"west\": \"{itemData.ModID}:block/{models[5]}\"", 8);
					ModelBlock.WriteLine("  }}", 9);
					ModelBlock.WriteLine("}}", 10);
					ModelBlock.Close();
					Console.WriteLine($"Expecting a file called {models[0]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[1]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[2]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[3]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[4]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[5]}.png to be in textures/block");
					Console.WriteLine($"Writing Item for Cube called: {itemData.EntryName}");
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
				if (itemData.ModelType == "Button")
				{
					Console.WriteLine($"Writing Block State for Button called: {itemData.EntryName}");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModID}/blockstates/");
					var Blockstate = File.CreateText($"Datagen/1.21.4/{itemData.ModID}/blockstates/{itemData.EntryName}.json");
					Blockstate.WriteLine("{{", 0);
					Blockstate.WriteLine("  \"variants\": {{", 1);
					Blockstate.WriteLine("    \"face=ceiling,facing=east,powered=false\": {{", 2);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}\",", 3);
					Blockstate.WriteLine("      \"x\": 180,", 4);
					Blockstate.WriteLine("      \"y\": 270", 5);
					Blockstate.WriteLine("    }},", 6);
					Blockstate.WriteLine("    \"face=ceiling,facing=east,powered=true\": {{", 7);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}_pressed\",", 8);
					Blockstate.WriteLine("      \"x\": 180,", 9);
					Blockstate.WriteLine("      \"y\": 270", 10);
					Blockstate.WriteLine("    }},", 11);
					Blockstate.WriteLine("    \"face=ceiling,facing=north,powered=false\": {{", 12);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}\",", 13);
					Blockstate.WriteLine("      \"x\": 180,", 14);
					Blockstate.WriteLine("      \"y\": 180", 15);
					Blockstate.WriteLine("    }},", 16);
					Blockstate.WriteLine("    \"face=ceiling,facing=north,powered=true\": {{", 17);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}_pressed\",", 18);
					Blockstate.WriteLine("      \"x\": 180,", 19);
					Blockstate.WriteLine("      \"y\": 180", 20);
					Blockstate.WriteLine("    }},", 21);
					Blockstate.WriteLine("    \"face=ceiling,facing=south,powered=false\": {{", 22);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}\",", 23);
					Blockstate.WriteLine("      \"x\": 180", 24);
					Blockstate.WriteLine("    }},", 25);
					Blockstate.WriteLine("    \"face=ceiling,facing=south,powered=true\": {{", 26);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}_pressed\",", 27);
					Blockstate.WriteLine("      \"x\": 180", 28);
					Blockstate.WriteLine("    }},", 29);
					Blockstate.WriteLine("    \"face=ceiling,facing=west,powered=false\": {{", 30);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}\",", 31);
					Blockstate.WriteLine("      \"x\": 180,", 32);
					Blockstate.WriteLine("      \"y\": 90", 33);
					Blockstate.WriteLine("    }},", 34);
					Blockstate.WriteLine("    \"face=ceiling,facing=west,powered=true\": {{", 35);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}_pressed\",", 36);
					Blockstate.WriteLine("      \"x\": 180,", 37);
					Blockstate.WriteLine("      \"y\": 90", 38);
					Blockstate.WriteLine("    }},", 39);
					Blockstate.WriteLine("    \"face=floor,facing=east,powered=false\": {{", 40);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}\",", 41);
					Blockstate.WriteLine("      \"y\": 90", 42);
					Blockstate.WriteLine("    }},", 43);
					Blockstate.WriteLine("    \"face=floor,facing=east,powered=true\": {{", 44);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}_pressed\",", 45);
					Blockstate.WriteLine("      \"y\": 90", 46);
					Blockstate.WriteLine("    }},", 47);
					Blockstate.WriteLine("    \"face=floor,facing=north,powered=false\": {{", 48);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}\"", 49);
					Blockstate.WriteLine("    }},", 50);
					Blockstate.WriteLine("    \"face=floor,facing=north,powered=true\": {{", 51);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}_pressed\"", 52);
					Blockstate.WriteLine("    }},", 53);
					Blockstate.WriteLine("    \"face=floor,facing=south,powered=false\": {{", 54);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}\",", 55);
					Blockstate.WriteLine("      \"y\": 180", 56);
					Blockstate.WriteLine("    }},", 57);
					Blockstate.WriteLine("    \"face=floor,facing=south,powered=true\": {{", 58);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}_pressed\",", 59);
					Blockstate.WriteLine("      \"y\": 180", 60);
					Blockstate.WriteLine("    }},", 61);
					Blockstate.WriteLine("    \"face=floor,facing=west,powered=false\": {{", 62);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}\",", 63);
					Blockstate.WriteLine("      \"y\": 270", 64);
					Blockstate.WriteLine("    }},", 65);
					Blockstate.WriteLine("    \"face=floor,facing=west,powered=true\": {{", 66);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}_pressed\",", 67);
					Blockstate.WriteLine("      \"y\": 270", 68);
					Blockstate.WriteLine("    }},", 69);
					Blockstate.WriteLine("    \"face=wall,facing=east,powered=false\": {{", 70);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}\",", 71);
					Blockstate.WriteLine("      \"uvlock\": true,", 72);
					Blockstate.WriteLine("      \"x\": 90,", 73);
					Blockstate.WriteLine("      \"y\": 90", 74);
					Blockstate.WriteLine("    }},", 75);
					Blockstate.WriteLine("    \"face=wall,facing=east,powered=true\": {{", 76);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}_pressed\",", 77);
					Blockstate.WriteLine("      \"uvlock\": true,", 78);
					Blockstate.WriteLine("      \"x\": 90,", 79);
					Blockstate.WriteLine("      \"y\": 90", 80);
					Blockstate.WriteLine("    }},", 81);
					Blockstate.WriteLine("    \"face=wall,facing=north,powered=false\": {{", 82);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}\",", 83);
					Blockstate.WriteLine("      \"uvlock\": true,", 84);
					Blockstate.WriteLine("      \"x\": 90", 85);
					Blockstate.WriteLine("    }},", 86);
					Blockstate.WriteLine("    \"face=wall,facing=north,powered=true\": {{", 87);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}_pressed\",", 88);
					Blockstate.WriteLine("      \"uvlock\": true,", 89);
					Blockstate.WriteLine("      \"x\": 90", 90);
					Blockstate.WriteLine("    }},", 91);
					Blockstate.WriteLine("    \"face=wall,facing=south,powered=false\": {{", 92);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}\",", 93);
					Blockstate.WriteLine("      \"uvlock\": true,", 94);
					Blockstate.WriteLine("      \"x\": 90,", 95);
					Blockstate.WriteLine("      \"y\": 180", 96);
					Blockstate.WriteLine("    }},", 97);
					Blockstate.WriteLine("    \"face=wall,facing=south,powered=true\": {{", 98);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}_pressed\",", 99);
					Blockstate.WriteLine("      \"uvlock\": true,", 100);
					Blockstate.WriteLine("      \"x\": 90,", 101);
					Blockstate.WriteLine("      \"y\": 180", 102);
					Blockstate.WriteLine("    }},", 103);
					Blockstate.WriteLine("    \"face=wall,facing=west,powered=false\": {{", 104);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}\",", 105);
					Blockstate.WriteLine("      \"uvlock\": true,", 106);
					Blockstate.WriteLine("      \"x\": 90,", 107);
					Blockstate.WriteLine("      \"y\": 270", 108);
					Blockstate.WriteLine("    }},", 109);
					Blockstate.WriteLine("    \"face=wall,facing=west,powered=true\": {{", 110);
					Blockstate.WriteLine($"      \"model\": \"{itemData.ModID}:block/{itemData.EntryName}_pressed\",", 111);
					Blockstate.WriteLine("      \"uvlock\": true,", 112);
					Blockstate.WriteLine("      \"x\": 90,", 113);
					Blockstate.WriteLine("      \"y\": 270", 114);
					Blockstate.WriteLine("    }}", 115);
					Blockstate.WriteLine("  }}", 116);
					Blockstate.WriteLine("}}", 117);
					Blockstate.Close();
					Console.WriteLine($"Writing Block Model for Button called: {itemData.EntryName}");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModID}/models/block/");
					var Button = File.CreateText($"Datagen/1.21.4/{itemData.ModID}/models/block/{itemData.EntryName}.json");
					Button.WriteLine("{{", 0);
					Button.WriteLine("  \"parent\": \"minecraft:block/button\",", 1);
					Button.WriteLine("  \"textures\": {{", 2);
					Button.WriteLine($"    \"texture\": \"{itemData.ModID}:block/{itemData.ModelTextureName}\"", 3);
					Button.WriteLine("  }}", 4);
					Button.WriteLine("}}", 5);
					Button.Close();
					var Button_Pressed = File.CreateText($"Datagen/1.21.4/{itemData.ModID}/models/block/{itemData.EntryName}_pressed.json");
					Button_Pressed.WriteLine("{{", 0);
					Button_Pressed.WriteLine("  \"parent\": \"minecraft:block/button_pressed\",", 1);
					Button_Pressed.WriteLine("  \"textures\": {{", 2);
					Button_Pressed.WriteLine($"    \"texture\": \"{itemData.ModID}:block/{itemData.ModelTextureName}\"", 3);
					Button_Pressed.WriteLine("  }}", 4);
					Button_Pressed.WriteLine("}}", 5);
					Button_Pressed.Close();
					var Button_Inventory = File.CreateText($"Datagen/1.21.4/{itemData.ModID}/models/block/{itemData.EntryName}_inventory.json");
					Button_Inventory.WriteLine("{{", 0);
					Button_Inventory.WriteLine("  \"parent\": \"minecraft:block/button_inventory\",", 1);
					Button_Inventory.WriteLine("  \"textures\": {{", 2);
					Button_Inventory.WriteLine($"    \"texture\": \"{itemData.ModID}:block/{itemData.ModelTextureName}\"", 3);
					Button_Inventory.WriteLine("  }}", 4);
					Button_Inventory.WriteLine("}}", 5);
					Button_Inventory.Close();
					Console.WriteLine($"Writing Item for Button called: {itemData.EntryName}");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModID}/items/");
					var ItemBlock = File.CreateText($"Datagen/1.21.4/{itemData.ModID}/items/{itemData.EntryName}.json");
					if (itemData.ItemTextureName == "")
					{
						ItemBlock.WriteLine("{{", 0);
						ItemBlock.WriteLine("  \"model\": {{", 1);
						ItemBlock.WriteLine("    \"type\": \"minecraft:model\",", 2);
						ItemBlock.WriteLine($"    \"model\": \"{itemData.ModID}:block/{itemData.EntryName}_inventory\"", 4);
						ItemBlock.WriteLine("  }}", 5);
						ItemBlock.WriteLine("}}", 6);
						ItemBlock.Close();
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
				}
			}
		}
	}
}