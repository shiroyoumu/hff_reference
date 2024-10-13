using System;
using UnityEngine;

public class BreakOnGrab : MonoBehaviour, IGrabbable
{
	public void OnGrab()
	{
		UnityEngine.Object.Destroy(base.GetComponent<FixedJoint>());
	}

	public void OnRelease()
	{
	}
}
