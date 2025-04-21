using MinecraftModDatagen.Utils;
using MinecraftModDatagen.Versions._1214.Language_Datagen;

namespace MinecraftModDatagen.Versions._1214
{
	public class LanguageDatagen
	{
		public static void Language_Datagen_Func(List<string> todoList)
		{
			// Define basic variables used by the Lang Datagen
			int Iterator = 1;
			List<List<string>> names = new List<List<string>>();
			List<List<string>> guids = new List<List<string>>();
			
			// Read Lines in the CSV
			for (Iterator = 1; Iterator < todoList.Count; Iterator++)
			{
				var NameSpaces = todoList[Iterator].Split(',').ToList()[0].Split(';').ToList();
				var Names = todoList[Iterator].Split(',').ToList()[1].Split(';').ToList();
				names.Add(Names);
				guids.Add(NameSpaces);
			}
			
			// Create the Language Provider
			for (Iterator = 0; Iterator < names.Count; Iterator++)
			{
				var guid = guids[Iterator][0];
				// Set up the Directory and a second iterator
				Directory.CreateDirectory($"Datagen/1.21.4/{guid}/lang/");
				int Iterator2 = 0;
				
				// Create and start the Language files
				var en_us = File.CreateText($"Datagen/1.21.4/{guid}/lang/en_us.json");
				en_us.WriteLine("{{", 0);
				
				// A foreach loop that gets each List of Names within the List<List<String>> names
				foreach (var Name in names)
				{
					
					// A foreach loop that gets each Name out of the Previously gnabbed List of Names
					foreach (var NameType in Name)
					{
						
						// If the Language within the Name fetched matches, do its datagen system
						if (NameType.Contains("en-us: "))
						{
							
							// Mark our Name and Name ID Variables
							var name = NameType.Replace("en-us: ", "");
							var nameID = Name[0];
							
							// Do the EN_US Datagen bit
							EnUsGen.WriteToEnUS(Iterator, Iterator2, name, nameID, guid, en_us);
						}
					}
					
					// Iterate the Iterators than run through the next List of Names
					Iterator2++;
					Iterator2++;
				}
				
				// Add in the creative tab and closing brackets
				en_us.WriteLine($"  \"creativetab.{guid}.{guid}\": \"{CapitalizeFuncs.CapitalizeWithSpaces(guid.Replace("_", " "))}\"", Iterator2);
				en_us.WriteLine("}}", Iterator2 + 1);
				
				// Close the Language files
				en_us.Close();
			}
		}
	}
}