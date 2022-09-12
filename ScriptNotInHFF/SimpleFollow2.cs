using System;
using UnityEngine;

// Token: 0x020001F0 RID: 496
public class SimpleFollow2 : MonoBehaviour
{
	// Token: 0x06000853 RID: 2131 RVA: 0x00052C1C File Offset: 0x0005101C
	public void LateUpdate()
	{
		if (!this.target)
		{
			return;
		}
		float y = this.target.eulerAngles.y;
		float b = this.target.position.y + this.height;
		float num = base.transform.eulerAngles.y;
		float num2 = base.transform.position.y;
		num = Mathf.LerpAngle(num, y, this.rotationDamping * Time.deltaTime);
		num2 = Mathf.Lerp(num2, b, this.heightDamping * Time.deltaTime);
		Quaternion rotation = Quaternion.Euler(0f, num, 0f);
		base.transform.position = this.target.position;
		base.transform.position -= rotation * Vector3.forward * this.distance;
		Vector3 position = base.transform.position;
		position.y = num2;
		base.transform.position = position;
		base.transform.LookAt(this.target);
	}

	// Token: 0x04000608 RID: 1544
	public Transform target;

	// Token: 0x04000609 RID: 1545
	public float distance = 10f;

	// Token: 0x0400060A RID: 1546
	public float height = 5f;

	// Token: 0x0400060B RID: 1547
	public float heightDamping = 2f;

	// Token: 0x0400060C RID: 1548
	public float rotationDamping = 3f;
}
