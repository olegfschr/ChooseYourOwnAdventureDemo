// (c) 2021 Oleg Fischer

using UnityEngine;

public class SetBackgroundAudioMessage : Message
{
	public AudioClip Sound { get; private set; }

	public SetBackgroundAudioMessage SetData(AudioClip sound)
	{
		Sound = sound;

		return this;
	}
}