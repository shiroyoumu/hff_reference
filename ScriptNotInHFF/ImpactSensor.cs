using System;
using UnityEngine;
using UnityEngine.Events;

public class ImpactSensor : MonoBehaviour
{
	private void OnCollisionStay(Collision collision)
	{
		if (collision.impulse.magnitude > this.threshold)
		{
			this.onThresholdExceeded.Invoke();
		}
	}

	public float threshold = 10f;

	public UnityEvent onThresholdExceeded;
}
