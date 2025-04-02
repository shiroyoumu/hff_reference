using System;
using UnityEngine;

// Token: 0x0200062C RID: 1580
public class ResetVelocity : MonoBehaviour, IReset
{
	// Token: 0x060020BA RID: 8378 RVA: 0x000E7574 File Offset: 0x000E5974
	public void ResetState(int checkpoint, int subObjectives)
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		if (component)
		{
			component.velocity = Vector3.zero;
		}
	}
}
