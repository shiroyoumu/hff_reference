using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraControllerOverridesZone : MonoBehaviour
{
	private void Start()
	{
		Camera main = Camera.main;
		this.targetController = ((main != null) ? main.GetComponentInParent<CameraController3>() : null);
		this.InitializeOverrides();
	}

	private void InitializeOverrides()
	{
		if (this.targetController != null)
		{
			this.cameraModeOverride.Initialize(delegate(CameraMode nextValue)
			{
				CameraMode mode = this.targetController.mode;
				this.targetController.mode = nextValue;
				return mode;
			}, delegate(CameraMode nextValue)
			{
				this.targetController.mode = nextValue;
			});
			this.fpsTargetOffsetOverride.Initialize(delegate(Vector3 nextValue)
			{
				Vector3 fpsTargetOffset = this.targetController.fpsTargetOffset;
				this.targetController.fpsTargetOffset = nextValue;
				return fpsTargetOffset;
			}, delegate(Vector3 nextValue)
			{
				this.targetController.fpsTargetOffset = nextValue;
			});
			this.overrides = new CameraControllerOverridesZone.ICameraControllerOverride[]
			{
				this.cameraModeOverride,
				this.fpsTargetOffsetOverride
			};
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag("Player") || this.targetController == null)
		{
			return;
		}
		foreach (CameraControllerOverridesZone.ICameraControllerOverride cameraControllerOverride in this.overrides)
		{
			cameraControllerOverride.Apply();
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (!other.CompareTag("Player") || this.targetController == null)
		{
			return;
		}
		foreach (CameraControllerOverridesZone.ICameraControllerOverride cameraControllerOverride in this.overrides)
		{
			cameraControllerOverride.Revert();
		}
	}

	[SerializeField]
	private CameraControllerOverridesZone.CameraControllerOverrideCameraMode cameraModeOverride;

	[SerializeField]
	private CameraControllerOverridesZone.CameraControllerOverrideVector3 fpsTargetOffsetOverride;

	private CameraControllerOverridesZone.ICameraControllerOverride[] overrides;

	private CameraController3 targetController;

	private interface ICameraControllerOverride
	{
		void Apply();

		void Revert();
	}

	[Serializable]
	private abstract class CameraControllerOverride<T> : CameraControllerOverridesZone.ICameraControllerOverride
	{
		public bool IsEnabled
		{
			[CompilerGenerated]
			get
			{
				return this.isEnabled;
			}
		}

		protected abstract T Value { get; }

		public void Initialize(Func<T, T> applyValueHandler, Action<T> revertValueHandler)
		{
			this.applyValueHandler = applyValueHandler;
			this.revertValueHandler = revertValueHandler;
		}

		public void Apply()
		{
			if (!this.IsEnabled && this.applyValueHandler != null)
			{
				return;
			}
			this.cachedValue = this.applyValueHandler(this.Value);
		}

		public void Revert()
		{
			if (!this.IsEnabled && this.revertValueHandler != null)
			{
				return;
			}
			this.revertValueHandler(this.cachedValue);
		}

		[SerializeField]
		protected bool isEnabled;

		private Func<T, T> applyValueHandler;

		private Action<T> revertValueHandler;

		private T cachedValue;
	}

	[Serializable]
	private class CameraControllerOverrideCameraMode : CameraControllerOverridesZone.CameraControllerOverride<CameraMode>
	{
		protected override CameraMode Value
		{
			[CompilerGenerated]
			get
			{
				return this.value;
			}
		}

		[SerializeField]
		private CameraMode value;
	}

	[Serializable]
	private class CameraControllerOverrideVector3 : CameraControllerOverridesZone.CameraControllerOverride<Vector3>
	{
		protected override Vector3 Value
		{
			[CompilerGenerated]
			get
			{
				return this.value;
			}
		}

		[SerializeField]
		private Vector3 value;
	}
}
