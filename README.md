# Minecraft Mod Datagen

This is a application which intends to do datagen for the user without the hassle of figuring out how to implement data gen into the mod.

## How do I use it?

1. Download the latest release version of the application.
2. Open and Extract the Zip.
3. RUN `MinecraftModDatagen.exe`.
4. Tell it the versioning system as of writing theres only a Release system.
5. Input the sought after minecraft version, at the moment there is only 1.21.4
6. Fill out the CSV that has been created in the executable folder for each item you want to generate, If the item has multiple model textures or item textures split it with a `;` Also do not use spaces in the rows to seperate the columns as its split specifically by comma.
7. Wait for generation to complete.
8. Once its complete check Datagen/[Version] for the datagened files.

## How to enter info by Model Type;

### How to Enter into the CSV

All models will be in the following format `Mod_ID, Entry name, Entry Model Type, Model Texture Name, Item Texture Name`

| Item | What It Is |
|:-:|:-:|
| Mod_ID | This is the mods ID, and is what is utilized to make the directory's in the output |
| Entry Name | This is the internal name for the item for example `planks` would be the internal name for oak planks |
| Entry Model Type | This is the way to set the type of Model that you are trying to create |
| Model Texture Name | This is essentially what sets the Model's Texture's if the model type has multiple than it needs to be split up by `;` symbols without spaces |
| Item Texture Name | This is optional but it is what sets the Item Texture for the newly added model or item. |

### Cube_All

Enter into the CSV something like `chisel_unlimited,bismuth_block,Cube_All,bismuth_block,` optionally the last part can be filled for a texture for the item rather than a model.

### Cube

Enter into the CSV something like `chisel_unlimited,bismuth_block,Cube,D;U;N;E;S;W,`

Model Texture Name is defined as;

| Symbol | Definition |
|:-:|:-:|
| D | The texture that shows on the bottom face of the Cube |
| U | The texture that shows on the top face of the Cube |
| N | The texture that shows on the front face of the Cube |
| E | The texture that shows on the left face of the Cube |
| S | The texture that shows on the back face of the Cube |
| D | The texture that shows on the right face of the Cube |

Again optionally the last part can be filled for a texture for the item rather than a model.

### Button

Enter into the CSV something like `chisel_unlimited,bismuth_button,Button,bismuth_block,` optionally the last part can be filled for a texture for the item rather than a model.