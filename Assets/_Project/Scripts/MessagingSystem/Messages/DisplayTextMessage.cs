// (c) 2021 Oleg Fischer

public class DisplayTextMessage : Message
{
	public float DisplayTime { get; private set; }

	public DisplayTextMessage SetData(float displayTime)
	{
		DisplayTime = displayTime;

		return this;
	}
}