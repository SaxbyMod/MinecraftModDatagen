﻿using MinecraftModDatagen.Utils;

namespace MinecraftModDatagen.Versions
{
	public static class Release1214
	{
		public static void Datagen()
		{
			int Iterator = 1;
			Console.WriteLine("1.21.4 Selected; Fill out the CSV added to the file directory this is executing for each item/block/etc you want to add!");
			var csv = File.CreateText("1.21.4.csv");
			csv.WriteLine("ModID, EntryName, ModelType, ModelTextureName, ItemTextureName", 0);
			csv.Close();
			Console.WriteLine("File Name is 1.21.4.csv");
			Console.Write("Press any key to continue...");
			Console.ReadKey();
			
			// Define our Data and TODO Iteration
			List<string> todoList = new List<string>();
			Dictionary<string, DataType> data = new Dictionary<string, DataType>();
			
			// Get Lines from the Created CSV
			foreach (var line in File.ReadAllLines("1.21.4.csv"))
			{
				todoList.Add(line);
			}
			
			// Get Properties from CSV Lines
			foreach (var line in todoList)
			{
				if (line == "ModID, EntryName, ModelType, ModelTextureName, ItemTextureName")
				{
					Console.WriteLine($"Skipping unnened line");
					continue;
				}
				var section = line.Split(',');
				var entryName = section[1];
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
				Console.WriteLine($"Datagenning for {item.Key}");
				var itemData = item.Value;
				List<string> EntryNames = itemData.EntryName.Split(';').ToList();
				var entry = EntryNames[0];
				List<string> namespaces = itemData.ModId.Split(';').ToList();
				itemData.ModId = namespaces[0];
				Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/lang/");
				var en_us = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/lang/en_us.json");
				en_us.WriteLine("{{", 0);
				if (itemData.ModelType == "Cube_All")
				{
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
					Console.WriteLine($"Writing Block Model(s) for Cube_All called: {entry}");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/block/");
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
					Console.WriteLine($"Expecting a file called {itemData.ModelTextureName}.png to be in textures/block");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/items/");
					var itemBlock = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/items/{entry}.json");
					if (itemData.ItemTextureName == "")
					{
						Console.WriteLine($"Writing Item for Cube_All called: {entry}");
						itemBlock.WriteLine("{{", 0);
						itemBlock.WriteLine("  \"model\": {{", 1);
						itemBlock.WriteLine("    \"type\": \"minecraft:model\",", 2);
						itemBlock.WriteLine($"    \"model\": \"{itemData.ModId}:block/{entry}_inventory\"", 4);
						itemBlock.WriteLine("  }}", 5);
						itemBlock.WriteLine("}}", 6);
						itemBlock.Close();
					}
					else
					{
						Console.WriteLine($"Writing Item for Cube_All called: {entry}");
						itemBlock.WriteLine("{{", 0);
						itemBlock.WriteLine("  \"model\": {{", 1);
						itemBlock.WriteLine("    \"type\": \"minecraft:model\",", 2);
						itemBlock.WriteLine($"    \"model\": \"{itemData.ModId}:item/{entry}\"", 3);
						itemBlock.WriteLine("  }}", 4);
						itemBlock.WriteLine("}}", 5);
						itemBlock.Close();
						Console.WriteLine($"Writing Item Model for Cube_All called: {entry}");
						Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/item/");
						var itemModel = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/item/{entry}.json");
						itemModel.WriteLine("{{", 0);
						itemModel.WriteLine("  \"parent\": \"minecraft:item/generated\",", 1);
						itemModel.WriteLine("  \"textures\": {{", 2);
						itemModel.WriteLine($"    \"layer0\": \"{itemData.ModId}:item/{itemData.ItemTextureName}\"", 3);
						itemModel.WriteLine("  }}", 4);
						itemModel.WriteLine("}}", 5);
						itemModel.Close();
						Console.WriteLine($"Expecting a file called {itemData.ItemTextureName}.png to be in textures/item");
					}
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/textures/block/");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/textures/item/");
					Console.WriteLine($"Iterator before increment: {Iterator}");
					en_us.WriteLine($"    \"block.{itemData.ModId}.{entry}\": \"{EntryNames[0]}\",", Iterator);
					en_us.WriteLine($"    \"item.{itemData.ModId}.{entry}\": \"{EntryNames[0]}\",", Iterator + 1);
					Iterator += 2;
					Console.WriteLine($"Iterator after increment: {Iterator}");
				}
				if (itemData.ModelType == "Cube")
				{
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
					Console.WriteLine($"Writing Block Model(s) for Cube called: {entry}");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/block/");
					List<string> models = itemData.ModelTextureName.Split(';').ToList();
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
					Console.WriteLine($"Expecting a file called {models[0]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[1]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[2]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[3]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[4]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[5]}.png to be in textures/block");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/items/");
					var itemBlock = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/items/{entry}.json");
					if (itemData.ItemTextureName == "")
					{
						Console.WriteLine($"Writing Item for Cube called: {entry}");
						itemBlock.WriteLine("{{", 0);
						itemBlock.WriteLine("  \"model\": {{", 1);
						itemBlock.WriteLine("    \"type\": \"minecraft:model\",", 2);
						itemBlock.WriteLine($"    \"model\": \"{itemData.ModId}:block/{entry}_inventory\"", 4);
						itemBlock.WriteLine("  }}", 5);
						itemBlock.WriteLine("}}", 6);
						itemBlock.Close();
					}
					else
					{
						Console.WriteLine($"Writing Item for Cube called: {entry}");
						itemBlock.WriteLine("{{", 0);
						itemBlock.WriteLine("  \"model\": {{", 1);
						itemBlock.WriteLine("    \"type\": \"minecraft:model\",", 2);
						itemBlock.WriteLine($"    \"model\": \"{itemData.ModId}:item/{entry}\"", 3);
						itemBlock.WriteLine("  }}", 4);
						itemBlock.WriteLine("}}", 5);
						itemBlock.Close();
						Console.WriteLine($"Writing Item Model for Cube called: {entry}");
						Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/item/");
						var itemModel = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/item/{entry}.json");
						itemModel.WriteLine("{{", 0);
						itemModel.WriteLine("  \"parent\": \"minecraft:item/generated\",", 1);
						itemModel.WriteLine("  \"textures\": {{", 2);
						itemModel.WriteLine($"    \"layer0\": \"{itemData.ModId}:item/{itemData.ItemTextureName}\"", 3);
						itemModel.WriteLine("  }}", 4);
						itemModel.WriteLine("}}", 5);
						itemModel.Close();
						Console.WriteLine($"Expecting a file called {itemData.ItemTextureName}.png to be in textures/item");
					}
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/textures/block/");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/textures/item/");
					Console.WriteLine($"Iterator before increment: {Iterator}");
					en_us.WriteLine($"    \"block.{itemData.ModId}.{entry}\": \"{EntryNames[0]}\",", Iterator);
					en_us.WriteLine($"    \"item.{itemData.ModId}.{entry}\": \"{EntryNames[0]}\",", Iterator + 1);
					Iterator += 2;
					Console.WriteLine($"Iterator after increment: {Iterator}");
				}
				if (itemData.ModelType == "Button")
				{
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
					Console.WriteLine($"Writing Block Model(s) for Button called: {entry}");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/block/");
					List<string> models = itemData.ModelTextureName.Split(';').ToList();
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
					Console.WriteLine($"Expecting a file called {models[0]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[1]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[2]}.png to be in textures/block");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/items/");
					var itemBlock = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/items/{entry}.json");
					if (itemData.ItemTextureName == "")
					{
						Console.WriteLine($"Writing Item for Button called: {entry}");
						itemBlock.WriteLine("{{", 0);
						itemBlock.WriteLine("  \"model\": {{", 1);
						itemBlock.WriteLine("    \"type\": \"minecraft:model\",", 2);
						itemBlock.WriteLine($"    \"model\": \"{itemData.ModId}:block/{entry}_inventory\"", 4);
						itemBlock.WriteLine("  }}", 5);
						itemBlock.WriteLine("}}", 6);
						itemBlock.Close();
					}
					else
					{
						Console.WriteLine($"Writing Item for Button called: {entry}");
						itemBlock.WriteLine("{{", 0);
						itemBlock.WriteLine("  \"model\": {{", 1);
						itemBlock.WriteLine("    \"type\": \"minecraft:model\",", 2);
						itemBlock.WriteLine($"    \"model\": \"{itemData.ModId}:item/{entry}\"", 3);
						itemBlock.WriteLine("  }}", 4);
						itemBlock.WriteLine("}}", 5);
						itemBlock.Close();
						Console.WriteLine($"Writing Item Model for Button called: {entry}");
						Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/item/");
						var itemModel = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/item/{entry}.json");
						itemModel.WriteLine("{{", 0);
						itemModel.WriteLine("  \"parent\": \"minecraft:item/generated\",", 1);
						itemModel.WriteLine("  \"textures\": {{", 2);
						itemModel.WriteLine($"    \"layer0\": \"{itemData.ModId}:item/{itemData.ItemTextureName}\"", 3);
						itemModel.WriteLine("  }}", 4);
						itemModel.WriteLine("}}", 5);
						itemModel.Close();
						Console.WriteLine($"Expecting a file called {itemData.ItemTextureName}.png to be in textures/item");
					}
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/textures/block/");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/textures/item/");
					Console.WriteLine($"Iterator before increment: {Iterator}");
					en_us.WriteLine($"    \"block.{itemData.ModId}.{entry}\": \"{EntryNames[0]}\",", Iterator);
					en_us.WriteLine($"    \"item.{itemData.ModId}.{entry}\": \"{EntryNames[0]}\",", Iterator + 1);
					Iterator += 2;
					Console.WriteLine($"Iterator after increment: {Iterator}");
				}
				if (itemData.ModelType == "Slab")
				{
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
					Console.WriteLine($"Writing Block Model(s) for Slab called: {entry}");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/block/");
					List<string> models = itemData.ModelTextureName.Split(';').ToList();
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
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/items/");
					var itemBlock = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/items/{entry}.json");
					if (itemData.ItemTextureName == "")
					{
						Console.WriteLine($"Writing Item for Slab called: {entry}");
						itemBlock.WriteLine("{{", 0);
						itemBlock.WriteLine("  \"model\": {{", 1);
						itemBlock.WriteLine("    \"type\": \"minecraft:model\",", 2);
						itemBlock.WriteLine($"    \"model\": \"{itemData.ModId}:block/{entry}_inventory\"", 4);
						itemBlock.WriteLine("  }}", 5);
						itemBlock.WriteLine("}}", 6);
						itemBlock.Close();
					}
					else
					{
						Console.WriteLine($"Writing Item for Slab called: {entry}");
						itemBlock.WriteLine("{{", 0);
						itemBlock.WriteLine("  \"model\": {{", 1);
						itemBlock.WriteLine("    \"type\": \"minecraft:model\",", 2);
						itemBlock.WriteLine($"    \"model\": \"{itemData.ModId}:item/{entry}\"", 3);
						itemBlock.WriteLine("  }}", 4);
						itemBlock.WriteLine("}}", 5);
						itemBlock.Close();
						Console.WriteLine($"Writing Item Model for Slab called: {entry}");
						Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/item/");
						var itemModel = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/item/{entry}.json");
						itemModel.WriteLine("{{", 0);
						itemModel.WriteLine("  \"parent\": \"minecraft:item/generated\",", 1);
						itemModel.WriteLine("  \"textures\": {{", 2);
						itemModel.WriteLine($"    \"layer0\": \"{itemData.ModId}:item/{itemData.ItemTextureName}\"", 3);
						itemModel.WriteLine("  }}", 4);
						itemModel.WriteLine("}}", 5);
						itemModel.Close();
						Console.WriteLine($"Expecting a file called {itemData.ItemTextureName}.png to be in textures/item");
					}
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/textures/block/");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/textures/item/");
					Console.WriteLine($"Iterator before increment: {Iterator}");
					en_us.WriteLine($"    \"block.{itemData.ModId}.{entry}\": \"{EntryNames[0]}\",", Iterator);
					en_us.WriteLine($"    \"item.{itemData.ModId}.{entry}\": \"{EntryNames[0]}\",", Iterator + 1);
					Iterator += 2;
					Console.WriteLine($"Iterator after increment: {Iterator}");
				}
				if (itemData.ModelType == "Stair")
				{
					Console.WriteLine($"Writing Block State for Stair called: {entry}");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/blockstates/");
					var blockstate = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/blockstates/{entry}.json");
					blockstate.WriteLine($$"""
					                       {
					                         "variants": {
					                           "facing=east,half=bottom,shape=inner_left": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_inner",
					                             "uvlock": true,
					                             "y": 270
					                           },
					                           "facing=east,half=bottom,shape=inner_right": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_inner"
					                           },
					                           "facing=east,half=bottom,shape=outer_left": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_outer",
					                             "uvlock": true,
					                             "y": 270
					                           },
					                           "facing=east,half=bottom,shape=outer_right": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_outer"
					                           },
					                           "facing=east,half=bottom,shape=straight": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}"
					                           },
					                           "facing=east,half=top,shape=inner_left": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_inner",
					                             "uvlock": true,
					                             "x": 180
					                           },
					                           "facing=east,half=top,shape=inner_right": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_inner",
					                             "uvlock": true,
					                             "x": 180,
					                             "y": 90
					                           },
					                           "facing=east,half=top,shape=outer_left": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_outer",
					                             "uvlock": true,
					                             "x": 180
					                           },
					                           "facing=east,half=top,shape=outer_right": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_outer",
					                             "uvlock": true,
					                             "x": 180,
					                             "y": 90
					                           },
					                           "facing=east,half=top,shape=straight": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}",
					                             "uvlock": true,
					                             "x": 180
					                           },
					                           "facing=north,half=bottom,shape=inner_left": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_inner",
					                             "uvlock": true,
					                             "y": 180
					                           },
					                           "facing=north,half=bottom,shape=inner_right": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_inner",
					                             "uvlock": true,
					                             "y": 270
					                           },
					                           "facing=north,half=bottom,shape=outer_left": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_outer",
					                             "uvlock": true,
					                             "y": 180
					                           },
					                           "facing=north,half=bottom,shape=outer_right": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_outer",
					                             "uvlock": true,
					                             "y": 270
					                           },
					                           "facing=north,half=bottom,shape=straight": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}",
					                             "uvlock": true,
					                             "y": 270
					                           },
					                           "facing=north,half=top,shape=inner_left": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_inner",
					                             "uvlock": true,
					                             "x": 180,
					                             "y": 270
					                           },
					                           "facing=north,half=top,shape=inner_right": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_inner",
					                             "uvlock": true,
					                             "x": 180
					                           },
					                           "facing=north,half=top,shape=outer_left": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_outer",
					                             "uvlock": true,
					                             "x": 180,
					                             "y": 270
					                           },
					                           "facing=north,half=top,shape=outer_right": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_outer",
					                             "uvlock": true,
					                             "x": 180
					                           },
					                           "facing=north,half=top,shape=straight": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}",
					                             "uvlock": true,
					                             "x": 180,
					                             "y": 270
					                           },
					                           "facing=south,half=bottom,shape=inner_left": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_inner"
					                           },
					                           "facing=south,half=bottom,shape=inner_right": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_inner",
					                             "uvlock": true,
					                             "y": 90
					                           },
					                           "facing=south,half=bottom,shape=outer_left": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_outer"
					                           },
					                           "facing=south,half=bottom,shape=outer_right": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_outer",
					                             "uvlock": true,
					                             "y": 90
					                           },
					                           "facing=south,half=bottom,shape=straight": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}",
					                             "uvlock": true,
					                             "y": 90
					                           },
					                           "facing=south,half=top,shape=inner_left": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_inner",
					                             "uvlock": true,
					                             "x": 180,
					                             "y": 90
					                           },
					                           "facing=south,half=top,shape=inner_right": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_inner",
					                             "uvlock": true,
					                             "x": 180,
					                             "y": 180
					                           },
					                           "facing=south,half=top,shape=outer_left": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_outer",
					                             "uvlock": true,
					                             "x": 180,
					                             "y": 90
					                           },
					                           "facing=south,half=top,shape=outer_right": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_outer",
					                             "uvlock": true,
					                             "x": 180,
					                             "y": 180
					                           },
					                           "facing=south,half=top,shape=straight": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}",
					                             "uvlock": true,
					                             "x": 180,
					                             "y": 90
					                           },
					                           "facing=west,half=bottom,shape=inner_left": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_inner",
					                             "uvlock": true,
					                             "y": 90
					                           },
					                           "facing=west,half=bottom,shape=inner_right": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_inner",
					                             "uvlock": true,
					                             "y": 180
					                           },
					                           "facing=west,half=bottom,shape=outer_left": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_outer",
					                             "uvlock": true,
					                             "y": 90
					                           },
					                           "facing=west,half=bottom,shape=outer_right": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_outer",
					                             "uvlock": true,
					                             "y": 180
					                           },
					                           "facing=west,half=bottom,shape=straight": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}",
					                             "uvlock": true,
					                             "y": 180
					                           },
					                           "facing=west,half=top,shape=inner_left": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_inner",
					                             "uvlock": true,
					                             "x": 180,
					                             "y": 180
					                           },
					                           "facing=west,half=top,shape=inner_right": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_inner",
					                             "uvlock": true,
					                             "x": 180,
					                             "y": 270
					                           },
					                           "facing=west,half=top,shape=outer_left": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_outer",
					                             "uvlock": true,
					                             "x": 180,
					                             "y": 180
					                           },
					                           "facing=west,half=top,shape=outer_right": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_outer",
					                             "uvlock": true,
					                             "x": 180,
					                             "y": 270
					                           },
					                           "facing=west,half=top,shape=straight": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}",
					                             "uvlock": true,
					                             "x": 180,
					                             "y": 180
					                           }
					                         }
					                       }
					                       """);
					blockstate.Close();
					Console.WriteLine($"Writing Block Model(s) for Stair called: {entry}");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/block/");
					List<string> models = itemData.ModelTextureName.Split(';').ToList();
					if (namespaces.Count == 1)
					{
						var stair = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}.json");
						stair.WriteLine($$"""
						                  {
						                    "parent": "minecraft:block/stairs",
						                    "textures": {
						                      "bottom": "{{itemData.ModId}}:block/{{models[0]}}",
						                      "side": "{{itemData.ModId}}:block/{{models[1]}}",
						                      "top": "{{itemData.ModId}}:block/{{models[2]}}"
						                    }
						                  }
						                  """);
						stair.Close();
						var stairinner = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}_inner.json");
						stairinner.WriteLine($$"""
						                       {
						                         "parent": "minecraft:block/inner_stairs",
						                         "textures": {
						                           "bottom": "{{itemData.ModId}}:block/{{models[3]}}",
						                           "side": "{{itemData.ModId}}:block/{{models[4]}}",
						                           "top": "{{itemData.ModId}}:block/{{models[5]}}"
						                         }
						                       }
						                       """);
						stairinner.Close();
						var stairouter = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}_outer.json");
						stairouter.WriteLine($$"""
						                       {
						                         "parent": "minecraft:block/outer_stairs",
						                         "textures": {
						                           "bottom": "{{itemData.ModId}}:block/{{models[6]}}",
						                           "side": "{{itemData.ModId}}:block/{{models[7]}}",
						                           "top": "{{itemData.ModId}}:block/{{models[8]}}"
						                         }
						                       }
						                       """);
						stairouter.Close();
					}
					else
					{
						var stair = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}.json");
						stair.WriteLine($$"""
						                  {
						                    "parent": "minecraft:block/stairs",
						                    "textures": {
						                      "bottom": "{{namespaces[1]}}:block/{{models[0]}}",
						                      "side": "{{namespaces[2]}}:block/{{models[1]}}",
						                      "top": "{{namespaces[3]}}:block/{{models[2]}}"
						                    }
						                  }
						                  """);
						stair.Close();
						var stairinner = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}_inner.json");
						stairinner.WriteLine($$"""
						                       {
						                         "parent": "minecraft:block/inner_stairs",
						                         "textures": {
						                           "bottom": "{{namespaces[4]}}:block/{{models[3]}}",
						                           "side": "{{namespaces[5]}}:block/{{models[4]}}",
						                           "top": "{{namespaces[6]}}:block/{{models[5]}}"
						                         }
						                       }
						                       """);
						stairinner.Close();
						var stairouter = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}_outer.json");
						stairouter.WriteLine($$"""
						                       {
						                         "parent": "minecraft:block/outer_stairs",
						                         "textures": {
						                           "bottom": "{{namespaces[7]}}:block/{{models[6]}}",
						                           "side": "{{namespaces[8]}}:block/{{models[7]}}",
						                           "top": "{{namespaces[9]}}:block/{{models[8]}}"
						                         }
						                       }
						                       """);
						stairouter.Close();
					}
					Console.WriteLine($"Expecting a file called {models[0]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[1]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[2]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[3]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[4]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[5]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[6]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[7]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[8]}.png to be in textures/block");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/items/");
					var itemBlock = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/items/{entry}.json");
					if (itemData.ItemTextureName == "")
					{
						Console.WriteLine($"Writing Item for Stair called: {entry}");
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
						Console.WriteLine($"Writing Item for Stair called: {entry}");
						itemBlock.WriteLine("{{", 0);
						itemBlock.WriteLine("  \"model\": {{", 1);
						itemBlock.WriteLine("    \"type\": \"minecraft:model\",", 2);
						itemBlock.WriteLine($"    \"model\": \"{itemData.ModId}:item/{entry}\"", 3);
						itemBlock.WriteLine("  }}", 4);
						itemBlock.WriteLine("}}", 5);
						itemBlock.Close();
						Console.WriteLine($"Writing Item Model for Stair called: {entry}");
						Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/item/");
						var itemModel = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/item/{entry}.json");
						itemModel.WriteLine("{{", 0);
						itemModel.WriteLine("  \"parent\": \"minecraft:item/generated\",", 1);
						itemModel.WriteLine("  \"textures\": {{", 2);
						itemModel.WriteLine($"    \"layer0\": \"{itemData.ModId}:item/{itemData.ItemTextureName}\"", 3);
						itemModel.WriteLine("  }}", 4);
						itemModel.WriteLine("}}", 5);
						itemModel.Close();
						Console.WriteLine($"Expecting a file called {itemData.ItemTextureName}.png to be in textures/item");
					}
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/textures/block/");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/textures/item/");
					Console.WriteLine($"Iterator before increment: {Iterator}");
					en_us.WriteLine($"    \"block.{itemData.ModId}.{entry}\": \"{EntryNames[0]}\",", Iterator);
					en_us.WriteLine($"    \"item.{itemData.ModId}.{entry}\": \"{EntryNames[0]}\",", Iterator + 1);
					Iterator += 2;
					Console.WriteLine($"Iterator after increment: {Iterator}");
				}
				if (itemData.ModelType == "Lever")
				{
					Console.WriteLine($"Writing Block State for Lever called: {entry}");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/blockstates/");
					var blockstate = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/blockstates/{entry}.json");
					blockstate.WriteLine($$"""
					                       {
					                         "variants": {
					                           "face=ceiling,facing=east,powered=false": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_on",
					                             "x": 180,
					                             "y": 270
					                           },
					                           "face=ceiling,facing=east,powered=true": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}",
					                             "x": 180,
					                             "y": 270
					                           },
					                           "face=ceiling,facing=north,powered=false": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_on",
					                             "x": 180,
					                             "y": 180
					                           },
					                           "face=ceiling,facing=north,powered=true": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}",
					                             "x": 180,
					                             "y": 180
					                           },
					                           "face=ceiling,facing=south,powered=false": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_on",
					                             "x": 180
					                           },
					                           "face=ceiling,facing=south,powered=true": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}",
					                             "x": 180
					                           },
					                           "face=ceiling,facing=west,powered=false": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_on",
					                             "x": 180,
					                             "y": 90
					                           },
					                           "face=ceiling,facing=west,powered=true": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}",
					                             "x": 180,
					                             "y": 90
					                           },
					                           "face=floor,facing=east,powered=false": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_on",
					                             "y": 90
					                           },
					                           "face=floor,facing=east,powered=true": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}",
					                             "y": 90
					                           },
					                           "face=floor,facing=north,powered=false": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_on"
					                           },
					                           "face=floor,facing=north,powered=true": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}"
					                           },
					                           "face=floor,facing=south,powered=false": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_on",
					                             "y": 180
					                           },
					                           "face=floor,facing=south,powered=true": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}",
					                             "y": 180
					                           },
					                           "face=floor,facing=west,powered=false": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_on",
					                             "y": 270
					                           },
					                           "face=floor,facing=west,powered=true": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}",
					                             "y": 270
					                           },
					                           "face=wall,facing=east,powered=false": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_on",
					                             "x": 90,
					                             "y": 90
					                           },
					                           "face=wall,facing=east,powered=true": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}",
					                             "x": 90,
					                             "y": 90
					                           },
					                           "face=wall,facing=north,powered=false": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_on",
					                             "x": 90
					                           },
					                           "face=wall,facing=north,powered=true": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}",
					                             "x": 90
					                           },
					                           "face=wall,facing=south,powered=false": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_on",
					                             "x": 90,
					                             "y": 180
					                           },
					                           "face=wall,facing=south,powered=true": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}",
					                             "x": 90,
					                             "y": 180
					                           },
					                           "face=wall,facing=west,powered=false": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}_on",
					                             "x": 90,
					                             "y": 270
					                           },
					                           "face=wall,facing=west,powered=true": {
					                             "model": "{{itemData.ModId}}:block/{{entry}}",
					                             "x": 90,
					                             "y": 270
					                           }
					                         }
					                       }
					                       """);
					blockstate.Close();
					Console.WriteLine($"Writing Block Model(s) for Lever called: {entry}");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/block/");
					List<string> models = itemData.ModelTextureName.Split(';').ToList();
					
					if (namespaces.Count == 1)
					{
						var lever = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}.json");
						lever.WriteLine($$"""
						                  {
						                      "ambientocclusion": false,
						                      "textures": {
						                          "particle": "{{itemData.ModId}}:block/{{models[0]}}",
						                          "base": "{{itemData.ModId}}:block/{{models[1]}}",
						                          "lever": "{{itemData.ModId}}:block/{{models[2]}}"
						                      },
						                      "elements": [
						                          {   "from": [ 5, -0.02, 4 ],
						                              "to": [ 11, 2.98, 12 ],
						                              "faces": {
						                                  "down":  { "uv": [ 5, 4, 11, 12 ], "texture": "#base", "cullface": "down" },
						                                  "up":    { "uv": [ 5, 4, 11, 12 ], "texture": "#base" },
						                                  "north": { "uv": [ 5, 0, 11,  3 ], "texture": "#base" },
						                                  "south": { "uv": [ 5, 0, 11,  3 ], "texture": "#base" },
						                                  "west":  { "uv": [ 4, 0, 12,  3 ], "texture": "#base" },
						                                  "east":  { "uv": [ 4, 0, 12,  3 ], "texture": "#base" }
						                              }
						                          },
						                          {   "from": [ 7, 1, 7 ],
						                              "to": [ 9, 11, 9 ],
						                              "rotation": { "origin": [ 8, 1, 8 ], "axis": "x", "angle": -45 },
						                              "faces": {
						                                  "up":    { "uv": [ 7, 6, 9,  8 ], "texture": "#lever" },
						                                  "north": { "uv": [ 7, 6, 9, 16 ], "texture": "#lever" },
						                                  "south": { "uv": [ 7, 6, 9, 16 ], "texture": "#lever" },
						                                  "west":  { "uv": [ 7, 6, 9, 16 ], "texture": "#lever" },
						                                  "east":  { "uv": [ 7, 6, 9, 16 ], "texture": "#lever" }
						                              }
						                          }
						                      ]
						                  }
						                  """);
						lever.Close();
						var lever_on = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}_on.json");
						lever_on.WriteLine($$"""
						                     {
						                         "ambientocclusion": false,
						                         "textures": {
						                             "particle": "{{itemData.ModId}}:block/{{models[3]}}",
						                             "base": "{{itemData.ModId}}:block/{{models[4]}}",
						                             "lever": "{{itemData.ModId}}:block/{{models[5]}}"
						                         },
						                         "elements": [
						                             {   "from": [ 5, -0.02, 4 ],
						                                 "to": [ 11, 2.98, 12 ],
						                                 "faces": {
						                                     "down":  { "uv": [ 5, 4, 11, 12 ], "texture": "#base", "cullface": "down" },
						                                     "up":    { "uv": [ 5, 4, 11, 12 ], "texture": "#base" },
						                                     "north": { "uv": [ 5, 0, 11,  3 ], "texture": "#base" },
						                                     "south": { "uv": [ 5, 0, 11,  3 ], "texture": "#base" },
						                                     "west":  { "uv": [ 4, 0, 12,  3 ], "texture": "#base" },
						                                     "east":  { "uv": [ 4, 0, 12,  3 ], "texture": "#base" }
						                                 }
						                             },
						                             {   "from": [ 7, 1, 7 ],
						                                 "to": [ 9, 11, 9 ],
						                                 "rotation": { "origin": [ 8, 1, 8 ], "axis": "x", "angle": 45 },
						                                 "faces": {
						                                     "up":    { "uv": [ 7, 6, 9,  8 ], "texture": "#lever" },
						                                     "north": { "uv": [ 7, 6, 9, 16 ], "texture": "#lever" },
						                                     "south": { "uv": [ 7, 6, 9, 16 ], "texture": "#lever" },
						                                     "west":  { "uv": [ 7, 6, 9, 16 ], "texture": "#lever" },
						                                     "east":  { "uv": [ 7, 6, 9, 16 ], "texture": "#lever" }
						                                 }
						                             }
						                         ]
						                     }
						                     """);
						lever_on.Close();
					}
					else
					{ 
						var lever = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}.json");
						lever.WriteLine($$"""
						                  {
						                      "ambientocclusion": false,
						                      "textures": {
						                          "particle": "{{namespaces[1]}}:block/{{models[0]}}",
						                          "base": "{{namespaces[2]}}:block/{{models[1]}}",
						                          "lever": "{{namespaces[3]}}:block/{{models[2]}}"
						                      },
						                      "elements": [
						                          {   "from": [ 5, -0.02, 4 ],
						                              "to": [ 11, 2.98, 12 ],
						                              "faces": {
						                                  "down":  { "uv": [ 5, 4, 11, 12 ], "texture": "#base", "cullface": "down" },
						                                  "up":    { "uv": [ 5, 4, 11, 12 ], "texture": "#base" },
						                                  "north": { "uv": [ 5, 0, 11,  3 ], "texture": "#base" },
						                                  "south": { "uv": [ 5, 0, 11,  3 ], "texture": "#base" },
						                                  "west":  { "uv": [ 4, 0, 12,  3 ], "texture": "#base" },
						                                  "east":  { "uv": [ 4, 0, 12,  3 ], "texture": "#base" }
						                              }
						                          },
						                          {   "from": [ 7, 1, 7 ],
						                              "to": [ 9, 11, 9 ],
						                              "rotation": { "origin": [ 8, 1, 8 ], "axis": "x", "angle": -45 },
						                              "faces": {
						                                  "up":    { "uv": [ 7, 6, 9,  8 ], "texture": "#lever" },
						                                  "north": { "uv": [ 7, 6, 9, 16 ], "texture": "#lever" },
						                                  "south": { "uv": [ 7, 6, 9, 16 ], "texture": "#lever" },
						                                  "west":  { "uv": [ 7, 6, 9, 16 ], "texture": "#lever" },
						                                  "east":  { "uv": [ 7, 6, 9, 16 ], "texture": "#lever" }
						                              }
						                          }
						                      ]
						                  }
						                  """);
						lever.Close();
						var lever_on = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/block/{entry}_on.json");
						lever_on.WriteLine($$"""
						                     {
						                         "ambientocclusion": false,
						                         "textures": {
						                             "particle": "{{namespaces[4]}}:block/{{models[3]}}",
						                             "base": "{{namespaces[5]}}:block/{{models[4]}}",
						                             "lever": "{{namespaces[6]}}:block/{{models[5]}}"
						                         },
						                         "elements": [
						                             {   "from": [ 5, -0.02, 4 ],
						                                 "to": [ 11, 2.98, 12 ],
						                                 "faces": {
						                                     "down":  { "uv": [ 5, 4, 11, 12 ], "texture": "#base", "cullface": "down" },
						                                     "up":    { "uv": [ 5, 4, 11, 12 ], "texture": "#base" },
						                                     "north": { "uv": [ 5, 0, 11,  3 ], "texture": "#base" },
						                                     "south": { "uv": [ 5, 0, 11,  3 ], "texture": "#base" },
						                                     "west":  { "uv": [ 4, 0, 12,  3 ], "texture": "#base" },
						                                     "east":  { "uv": [ 4, 0, 12,  3 ], "texture": "#base" }
						                                 }
						                             },
						                             {   "from": [ 7, 1, 7 ],
						                                 "to": [ 9, 11, 9 ],
						                                 "rotation": { "origin": [ 8, 1, 8 ], "axis": "x", "angle": 45 },
						                                 "faces": {
						                                     "up":    { "uv": [ 7, 6, 9,  8 ], "texture": "#lever" },
						                                     "north": { "uv": [ 7, 6, 9, 16 ], "texture": "#lever" },
						                                     "south": { "uv": [ 7, 6, 9, 16 ], "texture": "#lever" },
						                                     "west":  { "uv": [ 7, 6, 9, 16 ], "texture": "#lever" },
						                                     "east":  { "uv": [ 7, 6, 9, 16 ], "texture": "#lever" }
						                                 }
						                             }
						                         ]
						                     }
						                     """);
						lever_on.Close();
					}
					Console.WriteLine($"Expecting a file called {models[0]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[1]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[2]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[3]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[4]}.png to be in textures/block");
					Console.WriteLine($"Expecting a file called {models[5]}.png to be in textures/block");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/items/");
					var itemBlock = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/items/{entry}.json");
					Console.WriteLine($"Writing Item for Lever called: {entry}");
					itemBlock.WriteLine("{{", 0);
					itemBlock.WriteLine("  \"model\": {{", 1);
					itemBlock.WriteLine("    \"type\": \"minecraft:model\",", 2);
					itemBlock.WriteLine($"    \"model\": \"{itemData.ModId}:item/{entry}\"", 3);
					itemBlock.WriteLine("  }}", 4);
					itemBlock.WriteLine("}}", 5);
					itemBlock.Close();
					Console.WriteLine($"Writing Item Model for Lever called: {entry}");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/item/");
					var itemModel = File.CreateText($"Datagen/1.21.4/{itemData.ModId}/models/item/{entry}.json");
					itemModel.WriteLine("{{", 0);
					itemModel.WriteLine("  \"parent\": \"minecraft:item/generated\",", 1);
					itemModel.WriteLine("  \"textures\": {{", 2);
					itemModel.WriteLine($"    \"layer0\": \"{itemData.ModId}:item/{itemData.ItemTextureName}\"", 3);
					itemModel.WriteLine("  }}", 4);
					itemModel.WriteLine("}}", 5);
					itemModel.Close();
					Console.WriteLine($"Expecting a file called {itemData.ItemTextureName}.png to be in textures/item");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/textures/block/");
					Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/textures/item/");
					Console.WriteLine($"Iterator before increment: {Iterator}");
					en_us.WriteLine($"    \"block.{itemData.ModId}.{entry}\": \"{EntryNames[0]}\",", Iterator);
					en_us.WriteLine($"    \"item.{itemData.ModId}.{entry}\": \"{EntryNames[0]}\",", Iterator + 1);
					Iterator += 2;
					Console.WriteLine($"Iterator after increment: {Iterator}");
				}
				// Continue from this point
				en_us.WriteLine($"    \"creativetab.{itemData.ModId}.{itemData.ModId}\": \"{CapitalizeFuncs.CapitalizeWithSpaces(itemData.ModId)}\"", Iterator);
				en_us.WriteLine("}}", Iterator+1);
				en_us.Close();
				Console.WriteLine($"Finished datagenning for {item.Key}");
			}
		}
	}
}