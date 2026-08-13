using HarmonyLib;
using Verse;

namespace StkColoredDarklight;

[StaticConstructorOnStartup]
public static class Startup
{
	static Startup()
	{
		var harmony = new Harmony("stk.colored.darklights");
		harmony.PatchAll();
	}
}