using System;
using UnityEngine;

namespace GeoGame
{
	[CreateAssetMenu(fileName = "L1P2Controller", menuName = "Controller/PlayerTwoLevelOne", order = 1)]
	public class PlayerTwoLevelOne : PlayerScriptable
		{
			[SerializeField]
			private float speed;

			[SerializeField]
			private float jump;

			private bool canJump;

			public PlayerTwoLevelOne () : base() { canJump = true; }

			#region implemented abstract members of PlayerScriptable

			public override void MovePlayer(Rigidbody2D m_Rigidbody)
			{
				Vector2 curr_vel = m_Rigidbody.velocity;

			if (Input.GetKey(KeyCode.UpArrow) && canJump)
				{
					curr_vel.Set(curr_vel.x, jump);
				}

			if (Input.GetKey(KeyCode.DownArrow) )
				{

				}

			if (Input.GetKey(KeyCode.RightArrow))
				{
					curr_vel.Set(speed, curr_vel.y);
				}

			if (Input.GetKey(KeyCode.LeftArrow))
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


