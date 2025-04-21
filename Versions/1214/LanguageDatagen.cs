using MinecraftModDatagen.Utils;
using MinecraftModDatagen.Versions._1214.Language_Datagen;

namespace MinecraftModDatagen.Versions._1214
{
	public class LanguageDatagen
	{
		public static void Language_Datagen_Func(List<string> todoList)
		{
			int Iterator = 1;
			List<List<string>> names = new List<List<string>>();
			List<List<string>> guids = new List<List<string>>();
			// Read Lines in CSV than Language Provider
			for (Iterator = 0; Iterator < todoList.Count; Iterator++)
			{
				var NameSpaces = todoList[Iterator].Split(',').ToList()[0].Split(';').ToList();
				var Names = todoList[Iterator].Split(',').ToList()[1].Split(';').ToList();
				names.Add(Names);
				guids.Add(NameSpaces);
			}
			// Create Language Provider
			for (Iterator = 0; Iterator < names.Count; Iterator++)
			{
				Directory.CreateDirectory($"Datagen/1.21.4/{guids[Iterator][Iterator]}/lang/");
				int Iterator2 = 0;
				var en_us = File.CreateText($"Datagen/1.21.4/{guids[Iterator][Iterator]}/lang/en_us.json");
				en_us.WriteLine("{{", 0);
				foreach (var Name in names)
				{
					foreach (var NameType in Name)
					{
						if (NameType.Contains("en-us: "))
						{
							var name = NameType.Replace("en-us: ", "");
							var nameID = Name[0];
							EnUsGen.WriteToEnUS(Iterator, Iterator2, name, nameID, guids, en_us);
							en_us.WriteLine($"  \"creativetab.{guids[Iterator][Iterator]}.{guids[Iterator][Iterator]}\": \"{CapitalizeFuncs.CapitalizeWithSpaces(guids[Iterator][Iterator].Replace("_", " "))}\"", Iterator2 + 2);
							en_us.WriteLine("}}", Iterator2 + 3);
						}
					}
					Iterator2++;
					Iterator2++;
				}
				en_us.Close();
			}
		}
	}
}