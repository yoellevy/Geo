using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GeoGame
{
    public class MineScript : MonoBehaviour
    {

        bool isMine;
        // Use this for initialization
        void Start()
        {
            isMine = false;
            if (Random.Range(0, 10) < 2)
                isMine = true;

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            string colName = collision.name;
            print(colName);
            if (GetComponent<SpriteRenderer>().color != Color.black || (colName != "Player1" && colName != "Player2"))
                return;
            Color newColor = Color.black;
            float baseN = 255f;
            if (isMine)
            {
                newColor = new Color(254 / baseN, 184 / baseN, 112 / baseN);
                isMine = false;

                GameObject gm = GameObject.Find("GameManager");
                Vector3 pos = (gm.GetComponents<GameManager>()[0] as GameManager).firstMinePos;
                collision.transform.SetPositionAndRotation(new Vector3(pos.x + 0.16f, pos.y - 0.39f, pos.z), Quaternion.identity);

            }
            else
            {
                
                print(colName);
                if (colName == "Player1")
                {
                    newColor = new Color(217 / baseN, 97 / baseN, 83 / baseN);
                }
                if (colName == "Player2")
                {
                    newColor = new Color(132 / baseN, 191 / baseN, 195 / baseN);
                }
                newColor = new Color(253 / baseN, 247 / baseN, 215 / baseN);
            }
            GetComponent<SpriteRenderer>().color = newColor;
        }
    }
}