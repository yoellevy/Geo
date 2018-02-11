using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GeoGame {
	public class thirdLevelScript : MonoBehaviour {		
		[SerializeField] Transform plat;
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
			GameObject gm = GameObject.Find ("GameManager");
			Vector3 pos = collision.transform.position;
			float x = 3f;
			if (colName == "Player1")
				x = -3f;
			collision.transform.SetPositionAndRotation (new Vector3(x ,pos.y + 3f,pos.z), Quaternion.identity);
			collision.GetComponent<PlayerController>().updateControlScheme(Levels.FastClick);
			Transform col = transform.Find ("levelChanger");
			col.GetComponent<Collider2D> ().isTrigger = false;

			Instantiate (plat, new Vector3 (0, pos.y+2f, 0), Quaternion.identity);
//			this.GetComponentsInChildren<Collider> ()[0].isTrigger = false;
		}
	}

}
