using System;
using UnityEngine;

namespace HumanAPI
{
	public class MoveCart : MonoBehaviour
	{
		private void Awake()
		{
			this.cartRB = this.cart.GetComponent<Rigidbody>();
		}

		public void SetVal(bool val)
		{
			if (val != this.lastVal)
			{
				this.addForce = true;
				this.lastVal = val;
			}
		}

		private void FixedUpdate()
		{
			if (this.addForce)
			{
				this.addForce = false;
				this.cartRB.AddForce(new Vector3((float)((!this.direction) ? (-(float)this.force) : this.force), 0f, 0f));
			}
		}

		public void SetDirectionForward()
		{
			this.direction = false;
		}

		public void SetDirectionBackward()
		{
			this.direction = true;
		}

		private void OnGUI()
		{
		}

		public GameObject cart;

		public int force;

		private Rigidbody cartRB;

		private bool direction;

		private bool lastVal = true;

		private bool val = true;

		private bool addForce;
	}
}
