using System;
using UnityEngine;

namespace GeoGame
{
	[CreateAssetMenu(fileName = "L1P1Controller", menuName = "Controller/PlayerOneLevelOne", order = 1)]
	public class PlayerOneLevelOne : PlayerScriptable
	{
		[SerializeField]
		private float speed;

		[SerializeField]
		private float jump;

		private bool canJump;

		public PlayerOneLevelOne () : base() { canJump = true; }

		#region implemented abstract members of PlayerScriptable

		public override void MovePlayer(Rigidbody2D m_Rigidbody)
		{
			Vector2 curr_vel = m_Rigidbody.velocity;

			if (Input.GetKey(upKey) && canJump)
			{
				curr_vel.Set(curr_vel.x, jump);
			}

			if (Input.GetKey(downKey) )
			{
				
			}

			if (Input.GetKey(leftKey))
			{
				curr_vel.Set(speed, curr_vel.y);
			}

			if (Input.GetKey(rightKey))
			{
				curr_vel.Set(-speed, curr_vel.y);
			}
			m_Rigidbody.velocity = curr_vel;
		}
				
		public override void OnEnterCollision(Collision2D coliider)
		{
			canJump = true;
		}

		public override void OnExitCollision(Collision2D coliider)
		{
			canJump = false;
		}

		#endregion
	}
}

