using System;
using UnityEngine;

public class ChainFerry : MonoBehaviour
{
	private void Start()
	{
		this.startPos = this.boat.position;
	}

	private void Update()
	{
		if ((this.boat.position - this.startPos).z < 0f)
		{
			this.boat.MovePosition(this.startPos);
		}
		else if ((this.boat.position - this.startPos).z > this.maxDisp)
		{
			this.boat.MovePosition(this.startPos + this.maxDisp * Vector3.forward);
		}
	}

	[SerializeField]
	private Rigidbody boat;

	[SerializeField]
	private float maxDisp;

	private Vector3 startPos;
}
