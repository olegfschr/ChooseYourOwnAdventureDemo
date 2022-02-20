// (c) 2021 Oleg Fischer

public class FadeOutMessage : Message
{
	public float Duration { get; private set; }

	public FadeOutMessage SetData(float duration)
	{
		Duration = duration;

		return this;
	}
}