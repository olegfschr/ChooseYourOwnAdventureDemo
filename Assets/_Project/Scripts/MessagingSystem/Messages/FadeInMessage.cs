// (c) 2021 Oleg Fischer

public class FadeInMessage : Message
{
	public float Duration { get; private set; }

	public FadeInMessage SetData(float duration)
	{
		Duration = duration;

		return this;
	}
}