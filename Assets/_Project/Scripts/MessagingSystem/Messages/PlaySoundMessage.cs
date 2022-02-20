// (c) 2021 Oleg Fischer

using UnityEngine;

public class PlaySoundMessage : Message
{
	public AudioClip Sound { get; private set; }

	public PlaySoundMessage SetData(AudioClip sound)
	{
		Sound = sound;

		return this;
	}
}