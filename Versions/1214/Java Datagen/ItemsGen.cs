namespace MinecraftModDatagen.Versions._1214.Java_Datagen
{
	public class ItemsGen
	{
		public static void WriteToItem(List<string> Property, int IteratorCubes, StreamWriter Cubes, List<List<string>> names, string mod_id)
		{
			string name = names[IteratorCubes][0];
			string item = $"    public static final DeferredItem<Item> {name.ToUpper()} = ITEMS.register(\"{name}\", () -> new Item(new Item.Properties().setId(ResourceKey.create(Registries.ITEM, ResourceLocation.fromNamespaceAndPath(\"{mod_id}\", \"{name}\")))";

			foreach (var property in Property)
			{
				if (property.StartsWith("NoCombineRepair: ")) item += $".setNoCombineRepair()";
				if (property.StartsWith("Food: "))
				{
					var food = property.Replace("Food: ", "");
					var foodFormatted = food.Split(":").ToList();
					if (foodFormatted.Count < 2 || 2 < foodFormatted.Count) continue;
					var properties = foodFormatted[0];
					var consumable = foodFormatted[1];
					item += $".food({properties}, {consumable})";
				}
				if (property.StartsWith("UsingConvertsTo: ")) item += $".usingConvertsTo({property.Replace("UsingConvertsTo: ", "")})";
				if (property.StartsWith("UseCooldown: ")) item += $".useCooldown({property.Replace("UseCooldown: ", "")})";
				if (property.StartsWith("StacksTo: ")) item += $".stacksTo({property.Replace("StacksTo: ", "")})";
				if (property.StartsWith("Durability: ")) item += $".durability({property.Replace("Durability: ", "")})";
				if (property.StartsWith("CraftRemainder: ")) item += $".craftRemainder({property.Replace("CraftRemainder: ", "")})";
				if (property.StartsWith("Rarity: ")) item += $".rarity({property.Replace("Rarity: ", "")})";
			}

			item += "));";
			Cubes.WriteLine(item);
		}
	}
}