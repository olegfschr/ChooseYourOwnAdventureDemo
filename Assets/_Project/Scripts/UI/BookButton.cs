// (c) 2021 Oleg Fischer

using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Button controller, used to select a book.
/// </summary>
[RequireComponent(typeof(Button))]
public class BookButton : MonoBehaviour
{
	[SerializeField] private Image bookCover = default;
	[SerializeField] private TextMeshProUGUI bookTitle = default;
	[SerializeField] private AudioClip sound = default;

	private Button _button;

	public void Init(Sprite cover, string title, string bookId)
	{
		_button = GetComponent<Button>();
		bookCover.sprite = cover;
		bookTitle.text = title;

		_button.onClick.AddListener(() =>
		{
			MessageManager.SendMessage(MessageProvider.GetMessage<BookSelectedMessage>().SetData(bookId));
			MessageManager.SendMessage(MessageProvider.GetMessage<PlaySoundMessage>().SetData(sound));
		});
	}

	private void OnDestroy()
	{
		_button.onClick.RemoveAllListeners();
	}
}