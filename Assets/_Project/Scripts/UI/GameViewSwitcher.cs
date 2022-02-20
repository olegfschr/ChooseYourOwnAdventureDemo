// (c) 2021 Oleg Fischer

using DG.Tweening;
using UnityEngine;

/// <summary>
/// Used to switch game screens.
/// </summary>
public class GameViewSwitcher: MonoBehaviour, IMessageReceiver
{
	[SerializeField] private float screenSwitchDelay = 3f;
	[SerializeField] private float screenSwitchFadeTime = 2f;
	[SerializeField] private GameObject bookSelectScreen = default;
	[SerializeField] private GameObject bookViewScreen = default;

	private void Awake()
	{
		MessageManager.StartReceivingMessage<SwitchGameViewMessage>(this);
	}

	private void Start()
	{
		bookSelectScreen.SetActive(true);
		bookViewScreen.SetActive(false);
	}

	/// <inheritdoc />
	public void MessageReceived(Message message)
	{
		switch (message)
		{
			case SwitchGameViewMessage switchGameViewMessage:
				SwitchView(switchGameViewMessage.GameView);
				switchGameViewMessage.OnDoneUsing();
				break;
		}
	}

	private void SwitchView(GameView gameView)
	{
		DOTween.Sequence()
			.AppendCallback(() =>
			{
				MessageManager.SendMessage(MessageProvider.GetMessage<FadeOutMessage>().SetData(screenSwitchFadeTime));
			})
			.AppendInterval(screenSwitchDelay)
			.AppendCallback(() =>
			{
				switch (gameView)
				{
					case GameView.BookSelect:
						bookSelectScreen.SetActive(true);
						bookViewScreen.SetActive(false);
						break;
					case GameView.BookView:
						bookSelectScreen.SetActive(false);
						bookViewScreen.SetActive(true);
						break;
				}

				MessageManager.SendMessage(MessageProvider.GetMessage<FadeInMessage>().SetData(screenSwitchFadeTime));
			})
			;
	}

	private void OnDestroy()
	{
		MessageManager.StopReceivingAllMessages(this);
	}
}