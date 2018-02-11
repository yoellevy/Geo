using System;
using UnityEngine;

namespace GeoGame
{
	[CreateAssetMenu(fileName = "L34Controller", menuName = "Controller/LevelFourController", order = 1)]
	public class LevelFourController : PlayerScriptable
	{
		bool flag = true;
		[SerializeField] private float speed;
		public LevelFourController ()
		{
		}

		#region implemented abstract members of PlayerScriptable

		public override void MovePlayer (UnityEngine.Rigidbody2D m_Rigidbody)
		{
			Vector3 cur_pos = m_Rigidbody.transform.position;
			float x = cur_pos.x;
			float y = cur_pos.y;
			cur_pos.Set (x, y -0.1f, 0);
			if (Input.GetKeyDown(upKey) && flag) 
			{
				cur_pos.Set (x, y + speed, 0);
				flag = false;
			}
			if (Input.GetKeyUp (upKey))
				flag = true;
			
			m_Rigidbody.position = cur_pos;
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

