// (c) 2021 Oleg Fischer

public abstract class Feature
{
	/// <summary>
	/// Used to initialize feature.
	/// </summary>
	public abstract void Init();

	/// <summary>
	/// Used to cleanup feature's data.
	/// </summary>
	public abstract void Cleanup();
}