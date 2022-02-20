// (c) 2021 Oleg Fischer

using UnityEngine;

/// <summary>
/// Container which holds the books header data.
/// </summary>
[CreateAssetMenu(fileName = "AdventureTitle", menuName = "Adventure/Create new Adventure Title", order = 0)]
public class AdventureTitle : ScriptableObject
{
	[SerializeField] private string id = default;
	[SerializeField] private string userFriendlyName = default;
	[SerializeField] private Sprite titleImage = default;
	[SerializeField] private AdventureNode entryNode = default;

	public string Id => id;

	public string UserFriendlyName => userFriendlyName;

	public Sprite TitleImage => titleImage;

	public AdventureNode EntryNode => entryNode;
}