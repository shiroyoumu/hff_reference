using System;
using System.Collections.Generic;
using HumanAPI;
using UnityEngine;

public class MovementTracker : Node
{
	private void Start()
	{
		if (this.startTrigger != null)
		{
			this.startTrigger.OnEnterCollider += this.StartTracking;
		}
		if (this.floorTrigger != null)
		{
			this.floorTrigger.OnEnterCollider += this.StopTracking;
		}
		if (this.endTrigger != null)
		{
			this.endTrigger.OnEnterCollider += this.FinishTracking;
		}
	}

	private void StartTracking(Collider collider)
	{
		Debug.Log("StartTracking=" + collider.name);
		if (!this.playerColliders.Contains(collider))
		{
			this.playerColliders.Add(collider);
		}
	}

	private void StopTracking(Collider collider)
	{
		Debug.Log("StopTracking=" + collider.name);
		this.playerColliders.Remove(collider);
		if (this.playerColliders.Count == 0)
		{
			this.output.SetValue(0f);
		}
	}

	private void FinishTracking(Collider collider)
	{
		Debug.Log("FinishTracking=" + collider.name);
		if (this.playerColliders.Contains(collider))
		{
			this.output.SetValue(1f);
		}
		this.playerColliders.Remove(collider);
	}

	public TrackingTriggerVolume startTrigger;

	public TrackingTriggerVolume floorTrigger;

	public TrackingTriggerVolume endTrigger;

	public NodeOutput output;

	private List<Collider> playerColliders = new List<Collider>();
}
