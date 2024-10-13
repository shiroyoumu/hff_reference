using System;
using UnityEngine;

public class ConstantVelocity : MonoBehaviour
{
	private void Start()
	{
		this.rb = base.GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (this.rb != null)
		{
			this.rb.velocity = this.velocity * base.transform.forward * Time.deltaTime;
		}
	}

	private void OnDisable()
	{
		if (this.rb != null)
		{
			this.rb.velocity = Vector3.zero;
		}
	}

	[SerializeField]
	private float velocity;

	private Rigidbody rb;
}
