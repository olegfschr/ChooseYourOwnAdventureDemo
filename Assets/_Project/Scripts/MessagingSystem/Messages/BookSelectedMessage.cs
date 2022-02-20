// (c) 2021 Oleg Fischer

public class BookSelectedMessage : Message
{
	public string BookId { get; private set; }

	public BookSelectedMessage SetData(string bookId)
	{
		BookId = bookId;

		return this;
	}
}