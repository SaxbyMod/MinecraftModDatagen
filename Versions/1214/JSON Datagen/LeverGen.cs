using MinecraftModDatagen.Utils;

namespace MinecraftModDatagen.Versions._1214.JSON_Datagen
{
	public class LeverGen
	{
		public static void GenLever(DataType itemData, string entry, List<string> namespaces)
		{
			// Write the Lever's Blockstate
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
			
			// Write the Lever's Models
			Console.WriteLine($"Writing Block Model(s) for Lever called: {entry}");
			Directory.CreateDirectory($"Datagen/1.21.4/{itemData.ModId}/models/block/");
			List<string> models = itemData.ModelTextureName.Split(';').ToList();
			
			// This is done for the case that each texture stems from a different mod
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
			
			// Say that we expect X amount of textures in X folder
			Console.WriteLine($"Expecting a file called {models[0]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[1]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[2]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[3]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[4]}.png to be in textures/block");
			Console.WriteLine($"Expecting a file called {models[5]}.png to be in textures/block");
			
			// Generate our item, the last value is false as Lever's dont have a 3d model to utilize for inventory
			BlockItemGen.GenBlockItem(itemData, entry, "Lever", false);
		}
	}
}