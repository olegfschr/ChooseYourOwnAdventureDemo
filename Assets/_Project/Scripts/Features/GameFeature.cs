// (c) 2021 Oleg Fischer

using System.Collections.Generic;

/// <summary>
/// Feature which controls the game flow.
/// </summary>
public class GameFeature : Feature, IMessageReceiver
{
	private AdventureNode _currentNode;

	/// <inheritdoc />
	public override void Init()
	{
		MessageManager.StartReceivingMessage<OpenBookMessage>(this);
		MessageManager.StartReceivingMessage<OptionSelectedMessage>(this);
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
			case OpenBookMessage openBookMessage:
				_currentNode = openBookMessage.FirstNode;
				NextNode();
				openBookMessage.OnDoneUsing();
				break;
			case OptionSelectedMessage optionSelectedMessage:
				if (_currentNode.Transitions == null || _currentNode.Transitions.Length == 0)
				{
					// no transitions -  book is finished
					MessageManager.SendMessage(MessageProvider.GetMessage<SwitchGameViewMessage>().SetData(GameView.BookSelect));
				}
				else
				{
					_currentNode = _currentNode.Transitions[optionSelectedMessage.SelectedOptionIndex].NextNode;
					NextNode();
				}

				optionSelectedMessage.OnDoneUsing();
				break;
		}
	}

	private void NextNode()
	{
		var options = new List<string>();
		// check if reached the end of the branch
		if (_currentNode.Transitions == null || _currentNode.Transitions.Length == 0)
		{
			options.Add(Localization.Get("END"));
		}
		else
		{
			for (int i = 0; i < _currentNode.Transitions.Length; i++)
			{
				options.Add(Localization.Get(_currentNode.Transitions[i].Description));
			}

		}

		MessageManager.SendMessage(MessageProvider.GetMessage<NextNodeMessage>()
			.SetData(
				Localization.Get(_currentNode.NarrativeText),
				_currentNode.TitleImage,
				options
			));
	}
}