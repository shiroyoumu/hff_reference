using System;
using UnityEngine;

// Token: 0x02000005 RID: 5
[ExecuteInEditMode]
public class DistanceTool : MonoBehaviour
{
	// Token: 0x06000007 RID: 7 RVA: 0x00002137 File Offset: 0x00000537
	private void OnEnable()
	{
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002139 File Offset: 0x00000539
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = this.lineColor;
		Gizmos.DrawWireSphere(this.startPoint, this.gizmoRadius);
		Gizmos.DrawWireSphere(this.endPoint, this.gizmoRadius);
		Gizmos.DrawLine(this.startPoint, this.endPoint);
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002179 File Offset: 0x00000579
	private void OnDrawGizmos()
	{
		Gizmos.color = this.lineColor;
		Gizmos.DrawWireSphere(this.startPoint, this.gizmoRadius);
		Gizmos.DrawWireSphere(this.endPoint, this.gizmoRadius);
		Gizmos.DrawLine(this.startPoint, this.endPoint);
	}

	// Token: 0x0400000F RID: 15
	public string distanceToolName = string.Empty;

	// Token: 0x04000010 RID: 16
	public Color lineColor = Color.yellow;

	// Token: 0x04000011 RID: 17
	public bool initialized;

	// Token: 0x04000012 RID: 18
	public string initialName = "Distance Tool";

	// Token: 0x04000013 RID: 19
	public Vector3 startPoint = Vector3.zero;

	// Token: 0x04000014 RID: 20
	public Vector3 endPoint = new Vector3(0f, 1f, 0f);

	// Token: 0x04000015 RID: 21
	public float distance;

	// Token: 0x04000016 RID: 22
	public float gizmoRadius = 0.1f;

	// Token: 0x04000017 RID: 23
	public bool scaleToPixels;

	// Token: 0x04000018 RID: 24
	public int pixelPerUnit = 128;
}
