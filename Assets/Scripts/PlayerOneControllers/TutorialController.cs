using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GeoGame
{
    [CreateAssetMenu(fileName = "ToturialController", menuName = "Controller/ToturialControllere", order = 1)]
    class TutorialController : PlayerScriptable
    {

        [SerializeField]
        private float speed;

        [SerializeField]
        private float jump;

        private bool canJump;

        public TutorialController() : base() { canJump = true; }

        public override void MovePlayer(Rigidbody2D m_Rigidbody)
        {
            Vector2 curr_vel = m_Rigidbody.velocity;

            if (Input.GetKey(upKey) && canJump)
            {
                curr_vel.Set(curr_vel.x, jump);
                canJump = false;
            }

            if (Input.GetKey(downKey))
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
            if (coliider.gameObject.name == "ground")
                canJump = true;
        }

        public override void OnExitCollision(Collision2D coliider)
        {
            
        }
    }
}
