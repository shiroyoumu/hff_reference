using System;
using System.Collections.Generic;
using HumanAPI;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ObjectInSightDetector : Node
{
	private void Update()
	{
		if (this.humansInDetectionArea.Count > 0 && this.output.value < 0.5f)
		{
			this.CheckObjectPosition();
		}
	}

	private void OnTriggerEnter(Collider col)
	{
		foreach (Human human in Human.all)
		{
			if (human.IsLocalPlayer && !this.humansInDetectionArea.Contains(human))
			{
				if (human.GetComponent<Collider>() == col)
				{
					this.humansInDetectionArea.Add(human);
					break;
				}
			}
		}
	}

	private void OnTriggerExit(Collider col)
	{
		for (int i = this.humansInDetectionArea.Count - 1; i >= 0; i--)
		{
			if (this.humansInDetectionArea[i].GetComponent<Collider>() == col)
			{
				this.humansInDetectionArea.RemoveAt(i);
				break;
			}
		}
	}

	private void CheckObjectPosition()
	{
		if (this.IsObjectInSight())
		{
			this.output.SetValue(1f);
		}
	}

	private bool IsObjectInSight()
	{
		foreach (Human human in this.humansInDetectionArea)
		{
			Camera gameCam = human.player.cameraController.gameCam;
			Plane[] planes = GeometryUtility.CalculateFrustumPlanes(gameCam);
			if (GeometryUtility.TestPlanesAABB(planes, this.objectToTrack.bounds))
			{
				RaycastHit raycastHit;
				Physics.Raycast(gameCam.transform.position, Vector3.Normalize(this.objectToTrack.transform.position - gameCam.transform.position), out raycastHit, Vector3.Distance(this.objectToTrack.transform.position, gameCam.transform.position), this.layerMask.value);
				if (raycastHit.collider == this.objectToTrack)
				{
					return true;
				}
			}
		}
		return false;
	}

	public NodeOutput output;

	[SerializeField]
	private LayerMask layerMask;

	public Collider objectToTrack;

	private List<Human> humansInDetectionArea = new List<Human>();
}
