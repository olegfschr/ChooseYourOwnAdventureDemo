// (c) 2021 Oleg Fischer

using TMPro;
using UnityEngine;

/// <summary>
/// Localized text field.
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizedLabel : MonoBehaviour, IMessageReceiver
{
	[SerializeField] private string localizationKey;
	private TextMeshProUGUI _label;

	private void OnEnable()
	{
		if (_label == null) _label = GetComponent<TextMeshProUGUI>();
		_label.text = Localization.Get(localizationKey);
		MessageManager.StartReceivingMessage<LocalizeLabelMessage>(this);
	}

	private void OnDisable()
	{
		MessageManager.StopReceivingMessage<LocalizeLabelMessage>(this);
	}

	/// <inheritdoc />
	public void MessageReceived(Message message)
	{
		switch (message)
		{
			case LocalizeLabelMessage localizeLabelMessage:
				if (_label == null) _label = GetComponent<TextMeshProUGUI>();
				_label.text = Localization.Get(localizationKey);
				localizeLabelMessage.OnDoneUsing();
				break;
		}
	}
}