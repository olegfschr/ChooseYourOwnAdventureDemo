// (c) 2021 Oleg Fischer

using UnityEngine;

/// <summary>
/// Container for gameplay-specific settings.
/// </summary>
[CreateAssetMenu(fileName = "AdventuresSettings", menuName = "Adventure/Add Adventures Settings", order = 0)]
public class AdventuresSetting : ScriptableObject
{
	[SerializeField] private string adventureDataLocation;

	public string AdventureDataLocation => adventureDataLocation;
}