using System;
using UnityEngine;

namespace GeoGame
{
	[CreateAssetMenu(fileName = "L2P1Controller", menuName = "Controller/PlayerOneLevelTwo", order = 1)]
	public class PlayerOneLevelTwo : PlayerScriptable
	{
		[SerializeField]
		private float VerticalSpeed;

		[SerializeField]
		private float HorizontalSpeed;

		public PlayerOneLevelTwo ()
		{
		}

		#region implemented abstract members of PlayerScriptable

		public override void MovePlayer (UnityEngine.Rigidbody2D m_Rigidbody)
		{			
			Vector3 current_location = m_Rigidbody.position;

			if (Input.GetKey(upKey))
			{
				current_location.Set (current_location.x, current_location.y+VerticalSpeed,1f);			
			}

			if (Input.GetKey(downKey) )
			{
				current_location.Set (current_location.x, current_location.y-VerticalSpeed,1f);
			}

			if (Input.GetKey(leftKey))
			{
				current_location.Set (current_location.x+HorizontalSpeed, current_location.y,1f);
			}

			if (Input.GetKey(rightKey))
			{
				current_location.Set (current_location.x-HorizontalSpeed, current_location.y,1f);
			}
			m_Rigidbody.position = current_location;
		}

		public override void OnEnterCollision (Collision2D coliider)
		{
			
		}

		public override void OnExitCollision (Collision2D coliider)
		{
			
		}

		#endregion
	}
}

