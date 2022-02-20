// (c) 2021 Oleg Fischer

using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents a single page of a book, with text and storyline buttons.
/// </summary>
public class BookVisual : MonoBehaviour, IMessageReceiver
{
	[SerializeField] private TextMeshProUGUI pageText = default;
	[SerializeField] private Image pageIllustration = default;
	[SerializeField] private OptionButton[] optionsButtons = default;

	private void Awake()
	{
		MessageManager.StartReceivingMessage<NextNodeMessage>(this);
		for (int i = 0; i < optionsButtons.Length; i++)
		{
			optionsButtons[i].Init(i);
		}
	}

	private void OnDestroy()
	{
		MessageManager.StopReceivingAllMessages(this);
	}

	/// <inheritdoc />
	public void MessageReceived(Message message)
	{
		switch (message)
		{
			case NextNodeMessage nextNodeMessage:
				SetupButtons(nextNodeMessage.Options);
				SetupPage(nextNodeMessage.Text, nextNodeMessage.Illustration);
				nextNodeMessage.OnDoneUsing();
				break;
		}
	}

	private void SetupPage(string text, Sprite illustration)
	{
		pageText.text = string.Empty;
		pageText.DOText(text, 1f);
		DOTween.Sequence()
			.Append(pageIllustration.DOFade(0, 0.5f))
			.AppendCallback(() => { pageIllustration.sprite = illustration; })
			.Append(pageIllustration.DOFade(1f, 0.5f))
			;
	}

	private void SetupButtons(List<string> options)
	{
		for (int i = 0; i < optionsButtons.Length; i++)
		{
			optionsButtons[i].Hide();
		}

		for (int i = 0; i < options.Count; i++)
		{
			optionsButtons[i].SetLabel(options[i]);
			optionsButtons[i].Show();
		}

	}
}