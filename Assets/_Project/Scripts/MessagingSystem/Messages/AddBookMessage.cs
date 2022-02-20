// (c) 2021 Oleg Fischer

using UnityEngine;

public class AddBookMessage : Message
{
	public string BookId { get; private set; }
	public string BookTitle { get; private set; }
	public Sprite BookCover { get; private set; }

	public AddBookMessage SetData(string bookId, string bookTitle, Sprite bookCover)
	{
		BookId = bookId;
		BookTitle = bookTitle;
		BookCover = bookCover;

		return this;
	}
}