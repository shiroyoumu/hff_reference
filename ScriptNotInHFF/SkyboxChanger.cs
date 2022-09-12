using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200000A RID: 10
public class SkyboxChanger : MonoBehaviour
{
	// Token: 0x06000018 RID: 24 RVA: 0x00002FAC File Offset: 0x000013AC
	public void Awake()
	{
		this._dropdown = base.GetComponent<Dropdown>();
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00002FBA File Offset: 0x000013BA
	public void ChangeSkybox()
	{
		RenderSettings.skybox = this.Skyboxes[this._dropdown.value];
		RenderSettings.skybox.SetFloat("_Rotation", 0f);
	}

	// Token: 0x04000050 RID: 80
	public Material[] Skyboxes;

	// Token: 0x04000051 RID: 81
	private Dropdown _dropdown;
}
