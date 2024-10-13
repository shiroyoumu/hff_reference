using System;
using HumanAPI;
using Multiplayer;

public class NetBodyResetSensor : Node
{
	private void FixedUpdate()
	{
		if (ReplayRecorder.isPlaying || NetGame.isClient || this.bodyToTrack == null)
		{
			return;
		}
		this.value.SetValue((float)((!this.bodyToTrack.HandlingReset) ? 0 : 1));
		this.invertedValue.SetValue((float)((!this.bodyToTrack.HandlingReset) ? 1 : 0));
	}

	public NodeOutput value;

	public NodeOutput invertedValue;

	public NetBody bodyToTrack;
}
