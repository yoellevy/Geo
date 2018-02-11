using System;
using UnityEngine;

namespace GeoGame
{
	public abstract class PlayerScriptable : ScriptableObject 
	{		

		[SerializeField] protected string upKey;
		[SerializeField] protected string downKey;
		[SerializeField] protected string leftKey;
		[SerializeField] protected string rightKey;

		public PlayerScriptable ()
		{
		}

		public abstract void MovePlayer(Rigidbody2D m_Rigidbody);

		public abstract void OnEnterCollision(Collision2D coliider);
		public abstract void OnExitCollision(Collision2D coliider);

	}
}


