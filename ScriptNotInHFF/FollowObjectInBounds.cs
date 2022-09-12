using System;
using UnityEngine;

public class FollowObjectInBounds : MonoBehaviour
{
	private void FixedUpdate()
	{
		if (!this.objectToFollow)
		{
			return;
		}
		base.transform.position = this.boundaries.ClosestPoint(this.objectToFollow.transform.position);
	}

	public GameObject objectToFollow;

	[Tooltip("The boundaries this object should be constrained to")]
	public Collider boundaries;
}
