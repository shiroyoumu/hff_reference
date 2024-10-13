using System;
using System.Diagnostics;
using HumanAPI;
using Multiplayer;
using UnityEngine;

public class TrackingTriggerVolume : Node, INetBehavior, IReset
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event TrackingTriggerVolume.EnterColliderDelegate OnEnterCollider;

	private void Start()
	{
		if (this.output != null)
		{
			this.output.SetValue(this.outputValueOutside);
		}
		if (this.runExitLogicAtStartup)
		{
			this.SetExitObjectState(false);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		bool flag = false;
		if (this.IsCorrectCollider(other, out flag))
		{
			if (this.OnEnterCollider != null)
			{
				this.OnEnterCollider(other);
			}
			UnityEngine.Debug.Log("OnTriggerEnter" + flag);
			if (this.trackColliders)
			{
				this.colliderCount++;
				if (this.colliderCount > 1)
				{
					return;
				}
			}
			this.SetEnterObjectState(flag);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		bool exitObjectState = false;
		if (this.IsCorrectCollider(other, out exitObjectState))
		{
			if (this.trackColliders)
			{
				this.colliderCount--;
				if (this.colliderCount < 0)
				{
					this.colliderCount = 0;
				}
				if (this.colliderCount != 0)
				{
					return;
				}
			}
			this.SetExitObjectState(exitObjectState);
		}
	}

	private bool IsCorrectCollider(Collider other, out bool isPlayer)
	{
		bool flag = false;
		isPlayer = false;
		if (this.colliderToCheckFor == null && this.additionalColliders.Length == 0)
		{
			if (Human.Localplayer.GetComponent<Collider>() == other)
			{
				flag = true;
				isPlayer = true;
			}
			foreach (Human human in Human.all)
			{
				if (human.GetComponent<Collider>() == other)
				{
					flag = true;
					break;
				}
			}
		}
		else
		{
			flag = (other == this.colliderToCheckFor && this.colliderToCheckFor != null);
			if (!flag)
			{
				Transform transform = other.gameObject.transform;
				if (this.additionalColliders.Length != 0)
				{
					foreach (GameObject gameObject in this.additionalColliders)
					{
						if (transform.IsChildOf(gameObject.transform))
						{
							flag = true;
							break;
						}
					}
				}
			}
		}
		return flag;
	}

	private void SetEnterObjectState(bool isPlayer)
	{
		this.isActive = true;
		if (this.output != null)
		{
			this.output.SetValue(this.outputValueInside);
		}
		if (this.isPlayerCheckOnActivateAndDeactivate && !isPlayer)
		{
			return;
		}
		foreach (GameObject gameObject in this.activateOnEnter)
		{
			if (gameObject == null)
			{
				UnityEngine.Debug.LogError("Trigger Volume error @ Object " + base.gameObject.name);
			}
			else
			{
				gameObject.SetActive(true);
			}
		}
	}

	private void SetExitObjectState(bool isPlayer)
	{
		this.isActive = false;
		if (this.output != null)
		{
			this.output.SetValue(this.outputValueOutside);
		}
		if (this.isPlayerCheckOnActivateAndDeactivate && !isPlayer)
		{
			return;
		}
		foreach (GameObject gameObject in this.deactivateOnExit)
		{
			if (gameObject == null)
			{
				UnityEngine.Debug.LogError("Trigger Volume error @ Object " + base.gameObject.name);
			}
			else
			{
				gameObject.SetActive(false);
			}
		}
	}

	public void CollectState(NetStream stream)
	{
		NetBoolEncoder.CollectState(stream, this.isActive);
	}

	private void ApplyState(bool state)
	{
		if (state && !this.isActive)
		{
			this.SetEnterObjectState(false);
		}
		else if (!state && this.isActive)
		{
			this.SetEnterObjectState(false);
		}
	}

	public void ApplyState(NetStream state)
	{
		this.ApplyState(NetBoolEncoder.ApplyState(state));
	}

	public void ApplyLerpedState(NetStream state0, NetStream state1, float mix)
	{
		this.ApplyState(NetBoolEncoder.ApplyLerpedState(state0, state1, mix));
	}

	public void CalculateDelta(NetStream state0, NetStream state1, NetStream delta)
	{
		NetBoolEncoder.CalculateDelta(state0, state1, delta, true);
	}

	public void AddDelta(NetStream state0, NetStream delta, NetStream result)
	{
		NetBoolEncoder.AddDelta(state0, delta, result, true);
	}

	public int CalculateMaxDeltaSizeInBits()
	{
		return NetBoolEncoder.CalculateMaxDeltaSizeInBits();
	}

	public void StartNetwork(NetIdentity identity)
	{
	}

	public void SetMaster(bool isMaster)
	{
	}

	public void ResetState(int checkpoint, int subObjectives)
	{
		if (this.ignoreReset)
		{
			if (this.output != null)
			{
				this.output.SetValue((float)((this.colliderCount <= 0) ? 0 : 1));
			}
		}
		else
		{
			if (this.output != null)
			{
				this.output.SetValue(this.outputValueOutside);
			}
			this.colliderCount = 0;
		}
	}

	public override void Process()
	{
		base.Process();
		if (this.ignoreReset && this.output != null)
		{
			this.output.SetValue((float)((this.colliderCount <= 0) ? 0 : 1));
		}
	}

	public NodeOutput output;

	[Tooltip("Collider that will trigger this volume. If blank, any player will trigger.")]
	public Collider colliderToCheckFor;

	[Tooltip("Any gameobject that's a child of an entry in this list will also trigger output.")]
	public GameObject[] additionalColliders;

	[Tooltip("Value to output to the graph when players are inside the volume")]
	public float outputValueInside = 1f;

	[Tooltip("Value to output when the player is outside the volume")]
	public float outputValueOutside;

	[Tooltip("Trigger Activation and De-Activation only if its player, not for any clients")]
	public bool isPlayerCheckOnActivateAndDeactivate;

	[Tooltip("Array of gameobject to activate on entry")]
	public GameObject[] activateOnEnter;

	[Tooltip("Array of gameobjects to deactivate on exit")]
	public GameObject[] deactivateOnExit;

	public bool runExitLogicAtStartup;

	[Tooltip("If this is true, colliders are tracked as they enter/leave the volume and volume will deactivate only if no colliders are inside. Otherwise it will deactivate when any collider leaves even if others remain in the volume.")]
	public bool trackColliders = true;

	[Tooltip("Set this to \"true\" if this object's state should not be reset")]
	public bool ignoreReset;

	private int colliderCount;

	private bool isActive;

	public delegate void EnterColliderDelegate(Collider collider);
}
