using UnityEngine;

namespace Kiwi.Common.Utility
{
	public class FaceCamera : MonoBehaviour
	{
		private enum Axis { up, down, left, right, forward, back };

		[SerializeField] private Axis axis = Axis.up;
		[SerializeField] private bool reverseFace = false;

		private new Camera camera;

		private void Awake()
		{
			if (!camera)
				camera = Camera.main;
		}

		private void LateUpdate()
		{
			Vector3 faceDirection = reverseFace ? Vector3.back : Vector3.forward;
			Vector3 targetPos = transform.position + camera.transform.rotation * faceDirection;
			Vector3 targetOrientation = camera.transform.rotation * GetAxis(axis);
			transform.LookAt(targetPos, targetOrientation);
		}

		private Vector3 GetAxis(Axis refAxis)
		{
			switch (refAxis)
			{
				case Axis.down:
					return Vector3.down;
				case Axis.forward:
					return Vector3.forward;
				case Axis.back:
					return Vector3.back;
				case Axis.left:
					return Vector3.left;
				case Axis.right:
					return Vector3.right;
			}

			return Vector3.up;
		}
	}
}
