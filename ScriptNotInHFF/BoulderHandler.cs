using System;
using UnityEngine;

public class BoulderHandler : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.gameObject.tag != "Player")
		{
			return;
		}
		Rigidbody component = collision.collider.gameObject.GetComponent<Rigidbody>();
		component.velocity = Vector3.zero;
		component.angularVelocity = Vector3.zero;
		component.AddExplosionForce(this.forceToKnockPlayer, component.position, 10f, 20f, this.forceMode);
	}

	public float forceToKnockPlayer;

	public ForceMode forceMode;
}
