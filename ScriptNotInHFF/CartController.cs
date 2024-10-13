using System;
using UnityEngine;

public class CartController : MonoBehaviour
{
	public void StopMoving()
	{
		this.state = CartController.State.Stopped;
	}

	public void Start()
	{
		this.rigidbody = base.GetComponent<Rigidbody>();
	}

	public void Reset()
	{
		this.state = CartController.State.MovingToEnd;
	}

	public void FixedUpdate()
	{
		switch (this.state)
		{
		case CartController.State.MovingToEnd:
			this.rigidbody.MovePosition(base.transform.position + base.transform.forward * this.speed * Time.fixedDeltaTime);
			break;
		case CartController.State.WaitingAtEnd:
			this.endAwaitTimer -= Time.fixedDeltaTime;
			if (this.endAwaitTimer < 0f)
			{
				this.state = CartController.State.MovingToStart;
			}
			break;
		case CartController.State.MovingToStart:
			this.rigidbody.MovePosition(base.transform.position - base.transform.forward * this.speed * Time.fixedDeltaTime);
			break;
		case CartController.State.WaitingAtStart:
			this.startAwaitTimer -= Time.fixedDeltaTime;
			if (this.startAwaitTimer < 0f)
			{
				this.state = CartController.State.MovingToEnd;
			}
			break;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform == this.start)
		{
			this.state = CartController.State.WaitingAtStart;
			this.startAwaitTimer = this.waitTimeUnderGate;
			return;
		}
		if (other.transform == this.end)
		{
			this.state = CartController.State.WaitingAtEnd;
			this.endAwaitTimer = this.waitTimeOutsideHole;
			return;
		}
	}

	public float waitTimeUnderGate;

	public float waitTimeOutsideHole;

	public float speed = 1f;

	public Transform start;

	public Transform end;

	private Rigidbody rigidbody;

	private float startAwaitTimer;

	private float endAwaitTimer;

	private CartController.State state;

	private enum State
	{
		MovingToEnd,
		WaitingAtEnd,
		MovingToStart,
		WaitingAtStart,
		Stopped
	}
}
