// (c) 2021 Oleg Fischer

public class SwitchGameViewMessage : Message
{
	public GameView GameView { get; private set; }

	public SwitchGameViewMessage SetData(GameView gameView)
	{
		GameView = gameView;

		return this;
	}
}