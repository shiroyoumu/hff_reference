using System;
using HumanAPI;
using UnityEngine;

public class SignalSetTranslationForObject : Node
{
	protected override void OnEnable()
	{
		if (this.showDebug)
		{
			Debug.Log(base.name + " On Enable ");
		}
		base.OnEnable();
		this.body = this.objectToMove.GetComponent<Rigidbody>();
		if (this.transformLocal && this.body == null)
		{
			this.initialPosition = this.objectToMove.transform.localPosition;
		}
		else
		{
			this.initialPosition = this.objectToMove.transform.position;
		}
		if (this.triggerSignal != null)
		{
			this.triggerSignal.onValueChanged += this.SignalChanged;
			this.SignalChanged(this.triggerSignal.value);
		}
	}

	protected override void OnDisable()
	{
		if (this.showDebug)
		{
			Debug.Log(base.name + " On Disable");
		}
		base.OnDisable();
		if (this.triggerSignal != null)
		{
			this.triggerSignal.onValueChanged -= this.SignalChanged;
		}
	}

	public override void Process()
	{
		if (this.showDebug)
		{
			Debug.Log(base.name + " Process Signal ");
		}
		base.Process();
		this.SignalChanged(this.input.value);
	}

	private void SignalChanged(float val)
	{
		if (this.showDebug)
		{
			Debug.Log(base.name + " We are running the signal changed stuff ");
		}
		Vector3 b = val * this.multiplier * this.translationVector;
		if (this.body != null)
		{
			this.body.MovePosition(this.initialPosition + b);
		}
		else if (this.transformLocal)
		{
			this.objectToMove.transform.localPosition = this.initialPosition + b;
		}
		else
		{
			this.objectToMove.transform.position = this.initialPosition + b;
		}
	}

	[Tooltip("The incoming value to do something with")]
	public NodeInput input;

	[Tooltip("The amount of motion to apply when getting a signal0")]
	public float multiplier = 1f;

	[Tooltip("The axis to move the thing in ")]
	public Vector3 translationVector = new Vector3(1f, 0f, 0f);

	[Tooltip("Affect local translation rather than global. Doesn't currently work for rigid bodies")]
	public bool transformLocal;

	public GameObject objectToMove;

	[Tooltip("Trigge3r signal coming from somewhere ")]
	public SignalBase triggerSignal;

	private Rigidbody body;

	private Vector3 initialPosition;

	[Tooltip("Use this in order to show the prints coming from the script")]
	public bool showDebug;
}
