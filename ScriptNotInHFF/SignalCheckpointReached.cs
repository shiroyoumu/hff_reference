using System;
using HumanAPI;

public class SignalCheckpointReached : Node
{
	private void Update()
	{
		this.UpdateCurrentCheckpoint((!(Game.instance != null)) ? 0 : Game.instance.currentCheckpointNumber);
	}

	private void UpdateCurrentCheckpoint(int value)
	{
		if (value != this.lastCurrentCheckpointInternal)
		{
			this.lastCurrentCheckpointInternal = value;
			this.currentCheckpoint.SetValue((float)this.lastCurrentCheckpointInternal);
		}
	}

	private int lastCurrentCheckpointInternal;

	public NodeOutput currentCheckpoint;
}
