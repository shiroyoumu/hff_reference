using System;
using UnityEngine;

namespace HumanAPI
{
	public class DistanceAlong : Node
	{
		private void FixedUpdate()
		{
			this.value.SetValue(Vector3.Dot(base.transform.localPosition, this.axis));
		}

		public Vector3 axis;

		public NodeOutput value;
	}
}
