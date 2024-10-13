using System;
using HumanAPI;
using UnityEngine;

public class SignalShattered : Node
{
	private void Update()
	{
		if (this.previousValue != this.shatterObjectToTrack.shattered)
		{
			this.OnShatterStateChanged(this.shatterObjectToTrack.shattered);
			this.previousValue = this.shatterObjectToTrack.shattered;
		}
	}

	private void OnShatterStateChanged(bool value)
	{
		this.output.SetValue((float)((!value) ? 0 : 1));
	}

	public NodeOutput output;

	[SerializeField]
	private ShatterBase shatterObjectToTrack;

	private bool previousValue;
}
