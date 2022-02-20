// (c) 2021 Oleg Fischer

using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Feature which loads the books data and starts the game.
/// </summary>
public class SetupFeature : Feature, IMessageReceiver
{
	private readonly AdventuresSetting _setting;

	private readonly Dictionary<string, AdventureNode> _startingPoints;

	public SetupFeature(AdventuresSetting settings)
	{
		_setting = settings;
		MessageManager.StartReceivingMessage<BookSelectedMessage>(this);
		_startingPoints = new Dictionary<string, AdventureNode>();
	}

	/// <inheritdoc />
	public override void Init()
	{
		var adventureData = Resources.LoadAll<AdventureTitle>(_setting.AdventureDataLocation);
		foreach (var entry in adventureData)
		{
			_startingPoints.Add(entry.Id, entry.EntryNode);

			MessageManager.SendMessage(MessageProvider.GetMessage<AddBookMessage>()
				.SetData(entry.Id, Localization.Get(entry.UserFriendlyName), entry.TitleImage));
		}
	}

	/// <inheritdoc />
	public override void Cleanup()
	{
		MessageManager.StopReceivingAllMessages(this);
	}

	/// <inheritdoc />
	public void MessageReceived(Message message)
	{
		switch (message)
		{
			case BookSelectedMessage bookSelectedMessage:
				OpenBook(bookSelectedMessage.BookId);
				bookSelectedMessage.OnDoneUsing();
				break;
		}
	}

	private void OpenBook(string bookId)
	{
		MessageManager.SendMessage(MessageProvider.GetMessage<OpenBookMessage>().SetData(_startingPoints[bookId]));
		MessageManager.SendMessage(MessageProvider.GetMessage<SwitchGameViewMessage>().SetData(GameView.BookView));
	}
}