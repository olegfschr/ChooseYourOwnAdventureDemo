// (c) 2021 Oleg Fischer

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles localization of the game.
/// </summary>
public static class Localization
{
	private static Dictionary<string, string> _dict;

	/// <summary>
	/// Initializes dictionary.
	/// </summary>
	/// <param name="language">Dictionary's language.</param>
	public static void Init(SystemLanguage language)
	{
		var localizationTextFiles = Resources.LoadAll<TextAsset>($"Localization/{language}");
		Debug.Assert(localizationTextFiles.Length > 0, "[Localization] no localization files found!");
		_dict = new Dictionary<string, string>();

		foreach (var localizationTextFile in localizationTextFiles)
		{
			var lines = localizationTextFile.text.Split(new string[]{"\n"}, StringSplitOptions.RemoveEmptyEntries);
			foreach (var line in lines)
			{
				if (string.IsNullOrEmpty(line) || line.StartsWith("//")) continue;
				var localizationPair = line.Split(new string[]{"|"}, StringSplitOptions.RemoveEmptyEntries);
				if (localizationPair.Length != 2) continue;
				_dict.Add(localizationPair[0].Trim(), localizationPair[1].Trim());
			}
		}

		// localize labels
		MessageManager.SendMessage(MessageProvider.GetMessage<LocalizeLabelMessage>());
	}

	/// <summary>
	/// Get localized string.
	/// </summary>
	/// <param name="key">Localization key.</param>
	/// <returns>Localized string.</returns>
	public static string Get(string key) => _dict != null &&_dict.ContainsKey(key) ? _dict[key] : key;
}