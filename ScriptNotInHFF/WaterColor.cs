using System;
using UnityEngine;

// Token: 0x02000648 RID: 1608
public class WaterColor : MonoBehaviour
{
	// Token: 0x06002156 RID: 8534 RVA: 0x000EAFB0 File Offset: 0x000E93B0
	private void Start()
	{
		CaveRender component = GameObject.Find("GameCamera(Clone)").GetComponent<CaveRender>();
		if (component)
		{
			component.waterFogColor = this.color;
		}
	}

	// Token: 0x0400219E RID: 8606
	public Color color;
}
