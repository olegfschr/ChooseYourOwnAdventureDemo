// (c) 2021 Oleg Fischer

using UnityEngine;

/// <summary>
/// Used to generate and initialize book select buttons.
/// </summary>
public class BookSelector : MonoBehaviour, IMessageReceiver
{
	[SerializeField] private BookButton bookButtonPrefab = default;

	private void Awake()
	{
		MessageManager.StartReceivingMessage<AddBookMessage>(this);
	}

	/// <inheritdoc />
	public void MessageReceived(Message message)
	{
		switch (message)
		{
			case AddBookMessage addBookMessage:
				var bookButton = Instantiate(bookButtonPrefab, transform, true);
				bookButton.transform.localScale = Vector3.one;
				bookButton.Init(addBookMessage.BookCover, addBookMessage.BookTitle, addBookMessage.BookId);
				addBookMessage.OnDoneUsing();
				break;
		}
	}

	private void OnDestroy()
	{
		MessageManager.StopReceivingAllMessages(this);
	}
}