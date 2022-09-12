using System;
using UnityEngine;

// Token: 0x0200000B RID: 11
public class SkyboxRotator : MonoBehaviour
{
	// Token: 0x0600001B RID: 27 RVA: 0x00002FFA File Offset: 0x000013FA
	protected void Update()
	{
		if (this._rotate)
		{
			RenderSettings.skybox.SetFloat("_Rotation", Time.time * this.RotationPerSecond);
		}
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00003022 File Offset: 0x00001422
	public void ToggleSkyboxRotation()
	{
		this._rotate = !this._rotate;
	}

	// Token: 0x04000052 RID: 82
	public float RotationPerSecond = 1f;

	// Token: 0x04000053 RID: 83
	private bool _rotate;
}
