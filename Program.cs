// See https://aka.ms/new-console-template for more information

using MinecraftModDatagen.Versions;

Console.WriteLine("Which versioning system are you seeking; Releases or Screenshots?");
Console.Write("System: ");
var system = Console.ReadLine().ToUpper();

if (system == "RELEASE")
{
	Console.WriteLine("Input a minecraft version in Major Minor Bugfix form!");
	Console.Write("Version: ");
	var version = Console.ReadLine();
	if (version == "1.21.4")
	{
		Release1214.Datagen();
	}
}