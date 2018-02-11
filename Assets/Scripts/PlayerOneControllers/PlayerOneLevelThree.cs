using System;
using UnityEngine;

namespace GeoGame
{
	[CreateAssetMenu(fileName = "L3Controller", menuName = "Controller/LevelThreeController", order = 1)]
	public class PlayerOneLevelThree : PlayerScriptable
	{
		private int timeleft;
		private const int TIME_TO_MOVE = 20;
		public PlayerOneLevelThree ()
		{
			timeleft = 0;
		}

		#region implemented abstract members of PlayerScriptable

		public override void MovePlayer (UnityEngine.Rigidbody2D m_Rigidbody)
		{
			if (timeleft != 0) {
				timeleft -= 1;
				return;
			}

			bool up = Input.GetKey (upKey),
			down = Input.GetKey (downKey),
			left = Input.GetKey (leftKey),
			right = Input.GetKey (rightKey);

			Vector3 cur_pos = m_Rigidbody.transform.position;
			float x = cur_pos.x;
			float y = cur_pos.y;
			if (up && !left && !right && !down)
			{
				if (x == -3.59f)
					return;
				cur_pos.Set(cur_pos.x - 0.75f, cur_pos.y + 0.75f, cur_pos.z);
				timeleft = TIME_TO_MOVE;
			}
			else if (!up && !left && right && !down)
			{
				if (x == 3.91f)
					return;
				cur_pos.Set(cur_pos.x + 0.75f, cur_pos.y + 0.75f, cur_pos.z);
				timeleft = TIME_TO_MOVE;
			}
			else if (!up && left && !right && !down)
			{
				if (x == -3.59f)
					return;
				cur_pos.Set(cur_pos.x - 0.75f, cur_pos.y - 0.75f, cur_pos.z);
				timeleft = TIME_TO_MOVE;
			}
			else if (!up && !left && !right && down)
			{
				if (x == 3.91f)
					return;
				cur_pos.Set(cur_pos.x + 0.75f, cur_pos.y - 0.75f, cur_pos.z);
				timeleft = TIME_TO_MOVE;
			}
			m_Rigidbody.transform.SetPositionAndRotation(cur_pos, Quaternion.identity);
			m_Rigidbody.transform.Rotate(Vector3.back * 45f);
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

