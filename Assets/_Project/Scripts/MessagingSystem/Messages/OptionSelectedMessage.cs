// (c) 2021 Oleg Fischer

public class OptionSelectedMessage : Message
{
	public int SelectedOptionIndex { get; private set; }

	public OptionSelectedMessage SetData(int selectedOptionIndex)
	{
		SelectedOptionIndex = selectedOptionIndex;

		return this;
	}
}