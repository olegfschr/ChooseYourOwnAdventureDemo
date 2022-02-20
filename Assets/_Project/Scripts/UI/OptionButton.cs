// (c) 2021 Oleg Fischer

using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Option Button controller.
/// </summary>
[RequireComponent(typeof(Button), typeof(CanvasGroup))]
public class OptionButton : MonoBehaviour
{
	[SerializeField] private AudioClip buttonSound = default;

	private Button _button;
	private TextMeshProUGUI _label;
	private CanvasGroup _canvasGroup;
	private int _optionIndex;

	/// <summary>
	/// Setups the label's test.
	/// </summary>
	/// <param name="label">Label text.</param>
	public void SetLabel(string label)
	{
		_label.text = label;
	}

	/// <summary>
	/// Initializes the option button with given option.
	/// </summary>
	/// <param name="optionIndex">Option Index.</param>
	public void Init(int optionIndex)
	{
		_button = GetComponent<Button>();
		_label = GetComponentInChildren<TextMeshProUGUI>();
		_canvasGroup = GetComponent<CanvasGroup>();

		_optionIndex = optionIndex;
		_button.onClick.AddListener(() =>
		{
			MessageManager.SendMessage(MessageProvider.GetMessage<OptionSelectedMessage>().SetData(_optionIndex));
			MessageManager.SendMessage(MessageProvider.GetMessage<PlaySoundMessage>().SetData(buttonSound));
		});
	}

	/// <summary>
	/// Shows option button.
	/// </summary>
	public void Show()
	{
		_canvasGroup.DOFade(1f, 0.5f)
			.SetDelay(0.2f * _optionIndex)
			.OnComplete(() => _button.interactable = true)
			;
	}

	/// <summary>
	/// Hides options button.
	/// </summary>
	public void Hide()
	{
		_canvasGroup.alpha = 0;
		_button.interactable = false;
	}
}