using System;
using UnityEngine;

// Token: 0x0200060F RID: 1551
public class GrabBlocker : MonoBehaviour
{
	// Token: 0x06002057 RID: 8279 RVA: 0x000E60C3 File Offset: 0x000E44C3
	public void OnTriggerEnter(Collider other)
	{
		this.OnTriggerStay(other);
	}

	// Token: 0x06002058 RID: 8280 RVA: 0x000E60CC File Offset: 0x000E44CC
	public void OnTriggerStay(Collider other)
	{
		CollisionSensor component = other.GetComponent<CollisionSensor>();
		if (component)
		{
			component.ReleaseGrab(0f);
		}
	}
}
