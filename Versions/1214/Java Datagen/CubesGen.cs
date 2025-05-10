namespace MinecraftModDatagen.Versions._1214.Java_Datagen
{
	public class CubesGen
	{
		public static void WriteToCube(List<string> Property, int IteratorCubes, StreamWriter Cubes, List<List<string>> names, string mod_id)
		{
			string name = names[IteratorCubes][0];
			string block = $"	public static final DeferredBlock<Block> {name.ToUpper()} = RegisterBlocks(\"{name}\", () -> new Block(BlockBehaviour.Properties.of().setId(ResourceKey.create(Registries.BLOCK, ResourceLocation.fromNamespaceAndPath(\"{mod_id}\", \"{name}\")))";

			foreach (var property in Property)
			{
				if (property.StartsWith("Strength: ")) block += $".strength({property.Replace("Strength: ", "")})";
				if (property.StartsWith("RequiresCorrectToolForDrops: ")) block += ".requiresCorrectToolForDrops()";
				if (property.StartsWith("Sound: ")) block += $".sound(SoundType.{property.Replace("Sound: ", "")})";
				if (property.StartsWith("NoCollision: ")) block += ".noCollission()";
				if (property.StartsWith("MapColor: ")) block += $".mapColor(MapColor.{property.Replace("MapColor: ", "")})";
				if (property.StartsWith("NoOcclusion: ")) block += ".noOcclusion()";
				if (property.StartsWith("Friction: ")) block += $".friction({property.Replace("Friction: ", "")})";
				if (property.StartsWith("SpeedFactor: ")) block += $".speedFactor({property.Replace("SpeedFactor: ", "")})";
				if (property.StartsWith("JumpFactor: ")) block += $".jumpFactor({property.Replace("JumpFactor: ", "")})";
				if (property.StartsWith("LightLevel: ")) block += $".lightLevel(p_50874_ -> {property.Replace("LightLevel: ", "")})";
				if (property.StartsWith("Instabreak: ")) block += ".instabreak()";
				if (property.StartsWith("RandomTicks: ")) block += ".randomTicks()";
				if (property.StartsWith("DynamicShape: ")) block += ".dynamicShape()";
				if (property.StartsWith("NoLootTable: ")) block += ".noLootTable()";
			}

			block += "));";
			Cubes.WriteLine(block);
		}
	}
}