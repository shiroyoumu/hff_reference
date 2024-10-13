using System;
using UnityEngine;

public class CameraLevelOverride : MonoBehaviour
{
	private void Start()
	{
		this.mainCamera = Camera.main;
		this.initialCameraClipFarPlane = this.mainCamera.farClipPlane;
		this.mainCamera.farClipPlane = this.overrideCameraClipFarPlane;
	}

	private void OnDestroy()
	{
		Camera.main.farClipPlane = this.initialCameraClipFarPlane;
	}

	private Camera mainCamera;

	public float overrideCameraClipFarPlane = 300f;

	private float initialCameraClipFarPlane;
}
