// (c) 2021 Oleg Fischer

using System.Collections.Generic;
using UnityEngine;

public class NextNodeMessage : Message
{
	public string Text { get; private set; }
	public Sprite Illustration { get; private set; }
	public List<string> Options { get; private set; }

	public NextNodeMessage SetData(string text, Sprite illustration, List<string> options)
	{
		Text = text;
		Illustration = illustration;
		Options = options;

		return this;
	}
}