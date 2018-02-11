using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeoGame
{
    public class GateScript : MonoBehaviour
    {
        [SerializeField] bool isPlayer1 = true;

        static bool isRedTouch= false, isBlueTouch= false;
        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(isRedTouch && isBlueTouch)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().StartGame();

            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.name == "Player1" && isPlayer1)
            {
                isRedTouch = true;
            }
            else if (collision.name == "Player2" && !isPlayer1)
            {
                isBlueTouch = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.name == "Player1" && isPlayer1)
            {
                isRedTouch = false;
            }
            else if (collision.name == "Player2" && !isPlayer1)
            {
                isBlueTouch = false;
            }
        }
    }

}