using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeoGame
{
    public class PlayerController : MonoBehaviour
    {
        private Levels currentLevel;
        [SerializeField]
        public bool isDisable = false;

		private PlayerScriptable playerControl;
		[SerializeField]
		private List<PlayerScriptable> Controls = new List<PlayerScriptable>();

        Rigidbody2D m_Rigidbody;
        Collider2D m_Collider;

        // Use this for initialization
        void Start()
        {
            currentLevel = Levels.Maze;
            m_Rigidbody = GetComponent<Rigidbody2D>();
            m_Collider = GetComponent<Collider2D>();
			playerControl = Controls [4];
            m_Rigidbody.gravityScale = 2;
        }

        // Update is called once per frame
        void Update()
        {
            if (isDisable)
                return;
            movePlayer();
        }

        private void movePlayer()
        {            
			playerControl.MovePlayer (m_Rigidbody);
        }

        private void OnCollisionEnter2D(Collision2D coliider)
        {
			playerControl.OnEnterCollision (coliider);
        }

        private void OnCollisionExit2D(Collision2D coliider)
        {
			playerControl.OnExitCollision (coliider);
        }

        public void updateControlScheme(Levels level)
        {            
            currentLevel = level;
			if (level == Levels.ZigZag) {
				m_Rigidbody.gravityScale = 2;
                m_Collider.isTrigger = false;
                playerControl = Controls[0];
                m_Rigidbody.freezeRotation = false;
            } else if (level == Levels.Maze) {                
				m_Rigidbody.gravityScale = 0;
				m_Rigidbody.velocity = Vector2.zero;
				m_Rigidbody.freezeRotation = true;
                m_Collider.isTrigger = false;
                playerControl = Controls [1];
			} else if (level == Levels.Mine) {
				m_Rigidbody.gravityScale = 0;
				m_Rigidbody.velocity = Vector2.zero;
				playerControl = Controls [2];
                m_Rigidbody.freezeRotation = false;
                m_Collider.isTrigger = true;
			} else if (level == Levels.FastClick) {
				//m_Rigidbody.gravityScale = 1;
				m_Rigidbody.velocity = Vector2.zero;
				playerControl = Controls [3];
                m_Rigidbody.freezeRotation = false;
                m_Collider.isTrigger = false;
            }
        }
    }
}