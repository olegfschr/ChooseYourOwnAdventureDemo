// (c) 2021 Oleg Fischer

public class OpenBookMessage : Message
{
	public AdventureNode FirstNode { get; private set; }

	public OpenBookMessage SetData(AdventureNode firstNode)
	{
		FirstNode = firstNode;

		return this;
	}
}