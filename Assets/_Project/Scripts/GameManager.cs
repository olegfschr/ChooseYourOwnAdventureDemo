// (c) 2021 Oleg Fischer

using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bootstrapper class which manages features of the game.
/// </summary>
public class GameManager : MonoBehaviour
{
	[SerializeField] private UiSettings uiSettings = default;
	[SerializeField] private AdventuresSetting adventuresSetting = default;
	[SerializeField] private AudioSettings audioSettings  =default;

	private List<Feature> _features;

	private void Awake()
	{
		Localization.Init(SystemLanguage.English);
		_features = new List<Feature>()
		{
			new SetupFeature(adventuresSetting),
			new GameFeature(),
			new UiFeature(uiSettings)
		};
	}

	private void Start()
	{
		for (var i = 0; i < _features.Count; i++) _features[i].Init();
	}

	private void OnDestroy()
	{
		for (var i = 0; i < _features.Count; i++) _features[i].Cleanup();
	}
}