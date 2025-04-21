namespace MinecraftModDatagen.Versions._1214.Java_Datagen
{
	public class CubesGen
	{
		public static void WriteToCube(List<string> Property, int Iterator, int IteratorCubes, StreamWriter Cubes, List<List<string>> names)
		{
			foreach (var property in Property)
			{
				if (property.Contains("ModID: "))
				{
					Cubes.Write($$"""
					              import com.creator.chiselunlimited.ChiselUnlimited;
					              import com.creator.chiselunlimited.item.ModAddedItems;
					              import net.minecraft.core.registries.Registries;
					              import net.minecraft.resources.ResourceKey;
					              import net.minecraft.resources.ResourceLocation;
					              import net.minecraft.util.valueproviders.UniformInt;
					              import net.minecraft.world.item.BlockItem;
					              import net.minecraft.world.item.Item;
					              import net.minecraft.world.level.block.*;
					              import net.minecraft.world.level.block.state.BlockBehaviour;
					              import net.minecraft.world.level.block.state.properties.BlockSetType;
					              import net.neoforged.bus.api.IEventBus;
					              import net.neoforged.neoforge.registries.DeferredBlock;
					              import net.neoforged.neoforge.registries.DeferredRegister;
					              import net.neoforged.neoforge.registries.DeferredItem;
					              import java.util.function.Supplier;

					              public class ModAddedBlocks {
					              public static final DeferredRegister.Items ITEMS = DeferredRegister.createItems("{{property.Replace("ModID: ", "")}}");
					                  public static final DeferredRegister.Blocks BLOCKS = DeferredRegister.createBlocks("{{property.Replace("ModID: ", "")}}");
					                  private static <T extends Block> void RegisterItems(String Name, DeferredBlock<T> block) {ModAddedItems.ITEMS.register(Name, () -> new BlockItem(block.get(), new Item.Properties().setId(ResourceKey.create(Registries.ITEM, ResourceLocation.fromNamespaceAndPath({{property.Replace("ModID: ", "")}}, Name)))));}
					                  private static <T extends Block> DeferredBlock<T> RegisterBlocks(String Name, Supplier<T> block) {DeferredBlock<T> toReturn = BLOCKS.register(Name, block); RegisterItems(Name, toReturn); return toReturn;}
					              """,
						0);
				}
				else
				{
					Console.WriteLine("ERROR: SCREAMING BECAUSE YOU DID NOT INCLUDE A MODID.");
					Console.ReadLine();
				}
				string Block = $"public static final DeferredBlock<Block> {names[Iterator][Iterator].ToUpper()} =  RegisterMyBlocksAgain(\"{names[Iterator][Iterator]}\", () -> new Block(BlockBehaviour.Properties.of().setId(ResourceKey.create(Registries.BLOCK, ResourceLocation.fromNamespaceAndPath({property.Replace("ModID: ", "")}, \"{names[Iterator][Iterator]}\")))";
				// Property Defining Now;
				if (property.Contains("Strength: "))
				{
					Block = Block + $".strength({property.Replace("Strength: ", "")})";
				}
				if (property.Contains("RequiresCorrectToolForDrops: "))
				{
					Block = Block + ".requiresCorrectToolForDrops()";
				}
				if (property.Contains("Sound: "))
				{
					Block = Block + $".sound(SoundType.{property.Replace("Sound: ", "")}))";
				}
				if (property.Contains("NoCollision: "))
				{
					Block = Block + ".noCollission()";
				}
				if (property.Contains("MapColor: "))
				{
					Block = Block + $".mapColor(MapColor.{property.Replace("MapColor: ", "")})";
				}
				if (property.Contains("NoOcclusion: "))
				{
					Block = Block + ".noOcclusion()";
				}
				if (property.Contains("Friction: "))
				{
					Block = Block + $".friction({property.Replace("Friction: ", "")})";
				}
				if (property.Contains("SpeedFactor: "))
				{
					Block = Block + $".speedFactor({property.Replace("SpeedFactor: ", "")})";
				}
				if (property.Contains("JumpFactor: "))
				{
					Block = Block + $".jumpFactor({property.Replace("JumpFactor: ", "")})";
				}
				if (property.Contains("LightLevel: "))
				{
					Block = Block + $".lightLevel(p_50874_ -> {property.Replace("LightLevel: ", "")})";
				}
				if (property.Contains("Instabreak: "))
				{
					Block = Block + ".instabreak()";
				}
				Block = Block + "));";
				Cubes.Write(Block, 22);
			}
			IteratorCubes++;
		}
	}
}