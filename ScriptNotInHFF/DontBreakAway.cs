using System;
using UnityEngine;

public class DontBreakAway : MonoBehaviour
{
	private void Start()
	{
		this.joint = base.GetComponent<FixedJoint>();
	}

	private void Update()
	{
		Debug.Log(string.Format("joint force: {0}", this.joint.currentForce.magnitude));
		if (this.joint.currentForce.magnitude > this.thresholdForce)
		{
			Debug.Log("pulled");
			this.joint.connectedBody.AddForceAtPosition(-this.joint.currentForce * this.pullBackForceMultiplier, base.transform.position, ForceMode.Force);
		}
	}

	public float thresholdForce = 10000f;

	public float pullBackForceMultiplier = 1f;

	private FixedJoint joint;
}
