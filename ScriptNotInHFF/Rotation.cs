using System;
using UnityEngine;

public class Rotation : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		base.transform.Rotate(new Vector3(0f, this.speed * Time.deltaTime, 0f));
	}

	[SerializeField]
	private float speed;
}
