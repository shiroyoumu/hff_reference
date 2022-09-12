using System;
using UnityEngine;

public class ResetLeversPos : MonoBehaviour
{
	public void ResetStartPos()
	{
		this.leverMoveLR.transform.localPosition = this.leverMoveLRStart;
		this.leverAimLR.transform.localPosition = this.leverAimLRStart;
		this.leverAimUD.transform.localPosition = this.leverAimUDStart;
	}

	private void Awake()
	{
	}

	public Vector3 leverMoveLRStart;

	public Vector3 leverAimLRStart;

	public Vector3 leverAimUDStart;

	public GameObject leverMoveLR;

	public GameObject leverAimLR;

	public GameObject leverAimUD;
}
