// (c) 2021 Oleg Fischer

using DG.Tweening;
using TMPro;
using UnityEngine;

/// <summary>
/// USed to fade in/out of the UI text.
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
public class TextFader : MonoBehaviour, IMessageReceiver
{
	private TextMeshProUGUI _text;

	private void Awake()
	{
		_text = GetComponent<TextMeshProUGUI>();
		MessageManager.StartReceivingMessage<DisplayTextMessage>(this);
		_text.gameObject.SetActive(false);
	}

	/// <inheritdoc />
	public void MessageReceived(Message message)
	{
		switch (message)
		{
			case DisplayTextMessage displayTextMessage:
				_text.alpha = 0;
				_text.gameObject.SetActive(true);
				DOTween.Sequence()
					.Append(_text.DOFade(1f, 0.5f))
					.AppendInterval(displayTextMessage.DisplayTime)
					.Append(_text.DOFade(0f, 0.5f))
					.AppendCallback(() => _text.gameObject.SetActive(false))
					;
				displayTextMessage.OnDoneUsing();
				break;
		}
	}

	private void OnDestroy()
	{
		MessageManager.StopReceivingAllMessages(this);
	}
}