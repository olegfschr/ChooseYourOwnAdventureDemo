// (c) 2021 Oleg Fischer

using UnityEngine;

/// <summary>
/// Container which holds the data for the single book page.
/// </summary>
[CreateAssetMenu(fileName = "AdventureNode", menuName = "Adventure/Create new Adventure Node", order = 0)]
public class AdventureNode : ScriptableObject
{
	[SerializeField] private Sprite titleImage = default;
	[SerializeField] private string narrativeText = default;
	[SerializeField] private TransitionData[] transitions = default;

	public Sprite TitleImage => titleImage;

	public string NarrativeText => narrativeText;

	public TransitionData[] Transitions => transitions;
}