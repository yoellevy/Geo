using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GeoGame
{
	public class MazeScript : MonoBehaviour {

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			string colName = collision.name;
			if (colName != "Player1" && colName != "Player2")
				return;
			//GameObject gm = GameObject.Find ("GameManager");
			//Vector3 pos = (gm.GetComponents<GameManager>()[0] as GameManager).firstMinePos;
			//collision.transform.SetPositionAndRotation (new Vector3(pos.x +0.16f,pos.y - 0.4f,pos.z), Quaternion.identity);
			collision.GetComponent<PlayerController>().updateControlScheme(Levels.ZigZag);
		}
	}

}