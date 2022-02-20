// (c) 2021 Oleg Fischer

using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Used to fade in/out a screen overlay image.
/// </summary>
[RequireComponent(typeof(Image))]
public class Fader : MonoBehaviour, IMessageReceiver
{
	private Image _fader;

	private void Awake()
	{
		_fader = GetComponent<Image>();

		MessageManager.StartReceivingMessage<FadeInMessage>(this);
		MessageManager.StartReceivingMessage<FadeOutMessage>(this);
	}

	/// <inheritdoc />
	public void MessageReceived(Message message)
	{
		switch (message)
		{
			case FadeOutMessage fadeOutMessage:
				_fader.gameObject.SetActive(true);
				_fader.DOFade(1f, fadeOutMessage.Duration);
				fadeOutMessage.OnDoneUsing();
				break;
			case FadeInMessage fadeInMessage:
				_fader.DOFade(0f, fadeInMessage.Duration).OnComplete(() => _fader.gameObject.SetActive(false));
				fadeInMessage.OnDoneUsing();
				break;
		}
	}

	private void OnDestroy()
	{
		MessageManager.StopReceivingAllMessages(this);
	}
}