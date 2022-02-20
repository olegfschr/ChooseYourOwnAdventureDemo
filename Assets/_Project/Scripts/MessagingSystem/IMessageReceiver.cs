// (c) 2020 Oleg Fischer

public interface IMessageReceiver
{
	/// <summary>
	/// Called when object receives a message.
	/// </summary>
	/// <param name="message">Message object.</param>
	void MessageReceived(Message message);
}