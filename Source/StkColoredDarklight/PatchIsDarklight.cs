using HarmonyLib;
using UnityEngine;
using Verse;

namespace StkColoredDarklight;

[HarmonyPatch(typeof(DarklightUtility), nameof(DarklightUtility.IsDarklight))]
public static class PatchIsDarklight
{
	private const float minHueBrightlight = 1f/18f;
	private const float maxHueBrightlight = 4f/18f;

	[HarmonyPostfix]
	public static void Postfix(Color color, ref bool __result)
	{
		if (__result)
			return;

		Color.RGBToHSV(color, out float H, out float S, out _);
		if (S < 0.85f)
			return;
		
		__result = H < minHueBrightlight || H > maxHueBrightlight;
	}

}
