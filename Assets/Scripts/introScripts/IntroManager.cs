using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace GeoGame
{
    public class IntroManager : MonoBehaviour
    {
        [SerializeField] Transform level;
        [SerializeField] Transform movie;
        public bool isRedTouch = false;
        public bool isBlueTouch = false;

        // Use this for initialization
        void Start()
        {
            Invoke("makeGame", 3.6f);
        }

        // Update is called once per frame
        void Update()
        {
            if (isRedTouch && isBlueTouch)
            {
                SceneManager.LoadScene("Geo");
            }
        }

        void makeGame()
        {
            Destroy(movie.gameObject);
            SceneManager.LoadScene("Geo");
            //Instantiate(level, new Vector3(-0.4643559f, 0.1257949f, 0.03515625f), Quaternion.identity);
        }


    }


}