using UnityEngine;

namespace Kiwi.Common.Utility
{
	public class FaceCamera : MonoBehaviour
	{
		private enum Axis { up, down, left, right, forward, back };

		[SerializeField] private Axis axis = Axis.up;
		[SerializeField] private bool reverseFace = false;

		private Camera cameraToFace;

		private void Awake()
		{
			if (!cameraToFace)
				cameraToFace = Camera.main;
		}

		private void LateUpdate()
		{
			Vector3 faceDirection = reverseFace ? Vector3.back : Vector3.forward;
			Vector3 targetPos = transform.position + cameraToFace.transform.rotation * faceDirection;
			Vector3 targetOrientation = cameraToFace.transform.rotation * GetAxis(axis);
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
