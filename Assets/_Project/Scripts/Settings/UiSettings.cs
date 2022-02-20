// (c) 2021 Oleg Fischer

using UnityEngine;

/// <summary>
/// Container for UI-specific settings.
/// </summary>
[CreateAssetMenu(fileName = "UiSettings", menuName = "Adventure/Add UI Settings", order = 0)]
public class UiSettings : ScriptableObject
{
	[SerializeField] private float disclaimerDisplayTime = 3f;
	[SerializeField] private float fadeInTime = 2f;

	public float DisclaimerDisplayTime => disclaimerDisplayTime;

	public float FadeInTime => fadeInTime;
}