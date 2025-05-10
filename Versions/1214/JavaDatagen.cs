using MinecraftModDatagen.Versions._1214.Java_Datagen;

namespace MinecraftModDatagen.Versions._1214
{
	public class JavaDatagen
	{
		public static void Java_Datagen_Func(List<string> todoList)
		{
			var names = new List<List<string>>();
			var properties = new List<List<string>>();
			var guids = new List<List<string>>();

			for (int i = 1; i < todoList.Count; i++)
			{
				var parts = todoList[i].Split(',').Select(p => p.Trim()).ToList();

				if (parts.Count < 3)
				{
					Console.WriteLine($"Skipping invalid line {i}: {todoList[i]}");
					continue;
				}

				guids.Add(parts[0].Split(';').ToList());
				names.Add(parts[1].Split(';').ToList());
				properties.Add(parts[2].Split(';').ToList());
			}

			for (int i = 0; i < names.Count; i++)
			{
				var modIdProp = properties[i].FirstOrDefault(p => p.StartsWith("ModID: "));
				if (string.IsNullOrEmpty(modIdProp))
				{
					Console.WriteLine($"ERROR: Missing ModID in entry {i}. SCREAMING.");
					Console.ReadLine();
					return;
				}
				string guid = guids[i][0];
				string baseName = names[0][0];
				string modId = modIdProp.Replace("ModID: ", "");
				string outputPath = $"Datagen/1.21.4/{guid}/java/";
				Directory.CreateDirectory(outputPath);

				using StreamWriter cubes = File.CreateText(Path.Combine(outputPath, "Cubes.java"));
				using StreamWriter creativeTab = File.CreateText(Path.Combine(outputPath, "CreativeTab.java"));
				// Write class and ModID block header
				cubes.WriteLine($$"""
				                      package {{modId}}.blocks;
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
				                      
				                      public class Cubes {
				                          public static final DeferredRegister.Items ITEMS = DeferredRegister.createItems("{{modId}}");
				                          public static final DeferredRegister.Blocks BLOCKS = DeferredRegister.createBlocks("{{modId}}");
				                          
				                          public static void RegisterItemsBus(IEventBus itemBus) {
				                              ITEMS.register(itemBus);
				                      }
				                      
				                      public static void RegisterBlocksBus(IEventBus blockBus) {
				                          BLOCKS.register(blockBus);
				                      }
				                      
				                          private static <T extends Block> void RegisterItems(String Name, DeferredBlock<T> block) {
				                              ITEMS.register(Name, () -> new BlockItem(block.get(),
				                                  new Item.Properties().setId(ResourceKey.create(
				                                      Registries.ITEM,
				                                      ResourceLocation.fromNamespaceAndPath("{{modId}}", Name)
				                                  ))
				                              ));
				                          }
				                          
				                          private static <T extends Block> void RegisterMyBlockyItems(String Name, DeferredBlock<T> block) {
				                              ITEMS.register(
				                                  Name, () -> new BlockItem(
				                                      block.get(), 
				                                      new Item.Properties().setId(
				                                          ResourceKey.create(Registries.ITEM, ResourceLocation.fromNamespaceAndPath(ChiselUnlimited.MOD_ID, Name)
				                                          )
				                                      )
				                                  )
				                              );
				                          }
				                          
				                          private static <T extends Block> DeferredBlock<T> RegisterBlocks(String Name, Supplier<T> block) {
				                              DeferredBlock<T> toReturn = BLOCKS.register(Name, block);
				                              RegisterItems(Name, toReturn);
				                              return toReturn;
				                          }
				                          
				                  """);
				
				creativeTab.WriteLine($$"""
				                        package com.creator.chiselunlimited.item;
				                        import com.creator.chiselunlimited.ChiselUnlimited;
				                        import com.creator.chiselunlimited.block.ModAddedBlocks;
				                        import com.periut.chisel.Chisel;
				                        import net.minecraft.core.registries.Registries;
				                        import net.minecraft.network.chat.Component;
				                        import net.minecraft.world.item.CreativeModeTab;
				                        import net.minecraft.world.item.ItemStack;
				                        import net.neoforged.bus.api.IEventBus;
				                        import net.neoforged.neoforge.registries.DeferredRegister;
				                        import java.util.function.Supplier;
				                        
				                        public class CreativeTabs {
				                            // Create a Registry Bind for Creative Tabs
				                            public static final DeferredRegister<CreativeModeTab> CREATIVE_TABS = DeferredRegister.create(Registries.CREATIVE_MODE_TAB, ChiselUnlimited.MOD_ID);
				                        
				                            public static void RegisterTabs(IEventBus tabBus) {
				                                CREATIVE_TABS.register(tabBus);
				                            }
				                        
				                            // List of Tabs to Force-Feed Neoforge
				                            public static final Supplier<CreativeModeTab> {{guid.ToUpper()}} = CREATIVE_TABS.register("{{guid}}", () -> CreativeModeTab.builder()
				                                    .icon(()-> new ItemStack(Cubes.{{baseName.ToUpper()}}.get()))
				                                    .title(Component.translatable("creativetab.{{guid}}.{{guid}}"))
				                                    .displayItems((itemDisplayParameters, output) -> {
				                        """);
				int cubeIndex = 0;
				foreach (var propertyList in properties)
				{
					if (propertyList.Count == 0) continue;
					var type = propertyList[0];

					if (type == "Cube" || type == "Cube_All")
					{
						CubesGen.WriteToCube(propertyList, cubeIndex, cubes, names, modId);
						cubeIndex++;
					}
					if (type == "Item")
					{
						
					}
				}
				cubes.WriteLine("}");
				
				int creativeIndex = 0;
				foreach (var name in names)
				{
					if (name.Count == 0) continue;
					var internalName = name[0];
					if (properties.Count == 0) continue;
					var type = properties[creativeIndex][0];
					if (type == "Cube" || type == "Cube_All")
					{
						CreativeGen.WriteToCreativeCubes(name, creativeTab);
					}
					if (type == "Item")
					{
						CreativeGen.WriteToCreativeItems(name, creativeTab);
					}
				}
			}
		}
	}
}