// (c) 2021 Oleg Fischer

using DG.Tweening;

/// <summary>
/// UI controller feature.
/// </summary>
public class UiFeature : Feature
{
	private readonly UiSettings _settings;

	public UiFeature(UiSettings settings)
	{
		_settings = settings;
	}

	/// <inheritdoc />
	public override void Init()
	{
		OnGameStart();
	}

	/// <inheritdoc />
	public override void Cleanup() { }

	private void OnGameStart()
	{
		DOTween.Sequence()
			.AppendCallback(() =>
			{
				// fade out immediately
				MessageManager.SendMessage(MessageProvider.GetMessage<FadeOutMessage>().SetData(0));
			})
			.AppendInterval(1f)
			.AppendCallback(() =>
			{
				// show disclaimer text
				MessageManager.SendMessage(MessageProvider.GetMessage<DisplayTextMessage>()
					.SetData(_settings.DisclaimerDisplayTime));
			})
			.AppendInterval(_settings.DisclaimerDisplayTime + 1f)
			.AppendCallback(() =>
			{
				// fade in the menu screen
				MessageManager.SendMessage(MessageProvider.GetMessage<FadeInMessage>()
					.SetData(_settings.FadeInTime));
			})
			;
	}
}