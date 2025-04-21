using MinecraftModDatagen.Utils;

namespace MinecraftModDatagen.Versions._1214.JSON_Datagen
{
	public class StairGen
	{
		public static void GenStair(DataType itemData, string entry, List<string> namespaces)
		{
			// Write the Stair's Blockstate
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
			
			// Write the Stair's Blockmodels
			Console.WriteLine($"Writing Block Model(s) for Stair called: {entry}");
			Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/block/");
			List<string> models = itemData.ModelTextureName.Split(';').ToList();
			
			// This is done for the case that each texture stems from a different mod
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
			
			// Generate our item, the last value is true as Stair's have a 3d model to utilize for inventory
			BlockItemGen.GenBlockItem(itemData, entry, "Stair", true);
		}
	}
}