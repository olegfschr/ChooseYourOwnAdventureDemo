// (c) 2021 Oleg Fischer

using UnityEngine;

/// <summary>
/// PLays audio.
/// </summary>
public class AudioPlayer : MonoBehaviour, IMessageReceiver
{
	[SerializeField] private AudioSource backgroundSound = default;
	[SerializeField] private AudioSource oneShotSound = default;

	private void Awake()
	{
		MessageManager.StartReceivingMessage<PlaySoundMessage>(this);
		MessageManager.StartReceivingMessage<SetBackgroundAudioMessage>(this);
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
			case SetBackgroundAudioMessage setBackgroundSoundMessage:
				backgroundSound.clip = setBackgroundSoundMessage.Sound;
				backgroundSound.Play();
				setBackgroundSoundMessage.OnDoneUsing();
				break;
			case PlaySoundMessage playSoundMessage:
				oneShotSound.PlayOneShot(playSoundMessage.Sound);
				playSoundMessage.OnDoneUsing();
				break;
		}
	}
}