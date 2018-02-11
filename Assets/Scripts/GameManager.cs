using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GeoGame
{
    public enum Levels { ZigZag, Maze, Mine, FastClick, EndGame }
    public class GameManager : MonoBehaviour
    {
        private int player1Location;
        private Levels[] levelArray = new Levels[] { Levels.ZigZag, Levels.Maze };

        [SerializeField] Transform confeti;

        [SerializeField] private Transform playerOneCamera;
        [SerializeField] private Transform playerTwoCamera;

        [SerializeField] private float playerScopeSize;

        [SerializeField] private Transform playerOne;
        [SerializeField] private Transform playerTwo;

        [SerializeField] private Transform platformContainer;
        [SerializeField] private Transform platform;
        [SerializeField] private Transform platformEnd;
        [SerializeField] private int numberOfPlatforms;

        [SerializeField] private Transform levelChanger;

        [SerializeField] private Transform Maze;

        [SerializeField] private Transform mine;
        [SerializeField] private Transform mineContainer;

        [SerializeField] private Transform finishLine;

        [SerializeField] private float finishLineLocation=0;

        [SerializeField] private Transform winScreen;
        [SerializeField] private Transform loseScreen;

        public Vector3 firstMinePos;

        void createPlatforms()
        {
            float x, y;
            x = y = -1.5f;
            y = -0f;
            int i;
            for (i = 0; i < numberOfPlatforms; i++)
            {
                float a = Random.Range(-3.5f, 3.5f);

                Transform curr = Instantiate(platform, new Vector3(x + a, y + i * 2 + a, 2), Quaternion.identity, platformContainer);
            }
            Instantiate(platformEnd, new Vector3(-4.8f - 0.75f, i * 2 - 4.5f + 0.75f, 2), Quaternion.identity, platformContainer);
            Instantiate(levelChanger, new Vector3(0, i * 2 + 6.5f, 2), Quaternion.identity, this.transform);
        }

        void createMaze()
        {
            Instantiate(Maze, new Vector3(0, numberOfPlatforms * 2 + 12, 2), Quaternion.identity);
        }

        void createMines()
        {
            float mineStart = numberOfPlatforms * 2 + 7.45f;// + 18;
            firstMinePos = new Vector3(-3.0f, mineStart, 0);
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (((i % 2) == 1 && j == 6) || (i % 2 == 0 && (j == 0 || j == 6)))
                        continue;

                    Instantiate(mine, new Vector3(-4.5f + 1.5f * j + (i % 2) * 0.75f, mineStart + 0.75f * i, 0), Quaternion.identity, mineContainer);
                }
            }
            Transform go = Instantiate(levelChanger, new Vector3(0, mineStart + 14.5f, 2), Quaternion.identity, mineContainer);
            go.name = "levelChanger";
        }

        // Use this for initialization
        void Start()
        {
            createPlatforms();
            //createMaze();
            createMines();
            Instantiate(finishLine, new Vector3(0.5f, numberOfPlatforms * 2 + 25 + finishLineLocation, 2), Quaternion.identity);
            player1Location = 0;

            //Set controller
            //playerOne.GetComponent<PlayerController>().updateControlScheme(Levels.Maze);
            //playerTwo.GetComponent<PlayerController>().updateControlScheme(Levels.Maze);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.R))
                SceneManager.LoadScene("StartGame");
            //StartCoroutine(camera1Transition(playerOneCamera,playerOne));
            //StartCoroutine(camera2Transition(playerTwoCamera, playerTwo));
            cameraUpdate(playerOneCamera, playerOne);
            cameraUpdate(playerTwoCamera, playerTwo);
        }

        public float transitionDuration = 2.5f;
        Vector3 target;
        IEnumerator camera1Transition(Transform cam, Transform player)
        {
            float t = 0.0f;
            Vector3 startingPos = cam.position;
            target = new Vector3(cam.position.x, player.position.y, cam.position.z);
            while (t < 1.0f)
            {
                t += Time.deltaTime * (Time.timeScale / transitionDuration);

                cam.position = Vector3.Lerp(startingPos, target, t);
                yield return 0;
            }
        }

        IEnumerator camera2Transition(Transform cam, Transform player)
        {
            float t = 0.0f;
            Vector3 startingPos = cam.position;
            Vector3 target = new Vector3(cam.position.x, player.position.y, cam.position.z);
            while (t < 1.0f)
            {
                t += Time.deltaTime * (Time.timeScale / transitionDuration);

                cam.position = Vector3.Lerp(startingPos, target, t);
                yield return 0;
            }
        }

        public void StartGame()
        {
            playerOne.SetPositionAndRotation(new Vector3(-0.49f, -13.07f, 1),Quaternion.identity);
            playerOne.GetComponent<PlayerController>().updateControlScheme(Levels.Maze);
            playerTwo.SetPositionAndRotation(new Vector3(-0.49f, -11.72f, 1), Quaternion.identity);
            playerTwo.GetComponent<PlayerController>().updateControlScheme(Levels.Maze);
        }

        void cameraUpdate(Transform cam, Transform player)
        {
            float diff = player.position.y - cam.transform.position.y;
            float diffabs = Mathf.Abs(diff);

            if (diffabs > playerScopeSize)
            {
                float toAdd = diff > 0 ? diffabs - playerScopeSize : playerScopeSize - diffabs;
                cam.SetPositionAndRotation(new Vector3(cam.position.x, cam.position.y + toAdd, -1), new Quaternion());
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            string colName = collision.name;
            if (colName != "Player1" && colName != "Player2")
                return;

            if (collision.name == "Player1")
                player1Location += 1;

            //Vector3 pos = (gm.GetComponents<GameManager>()[0] as GameManager).firstMinePos;
            //collision.transform.SetPositionAndRotation (new Vector3(pos.x +0.16f,pos.y - 0.4f,pos.z), Quaternion.identity);

            collision.transform.SetPositionAndRotation(new Vector3(firstMinePos.x+0.16f,
                                                                   firstMinePos.y - 0.39f, 0), Quaternion.identity);
            collision.GetComponent<PlayerController>().updateControlScheme(Levels.Mine);
        }

        public void FinishGame()
        {
            playerOne.GetComponent<Rigidbody2D>().gravityScale = 0;
            playerOne.GetComponent<PlayerController>().isDisable = true;

            playerTwo.GetComponent<Rigidbody2D>().gravityScale = 0;
            playerTwo.GetComponent<PlayerController>().isDisable = true;

            if (playerOne.position.y > playerTwo.position.y)
            {
                Instantiate(confeti, new Vector3(0, playerOne.position.y+3f, 1), Quaternion.identity);
                Transform t = Instantiate(loseScreen, new Vector3(0, playerTwoCamera.position.y, 0), Quaternion.identity);
                t.gameObject.layer = 9;
                t = Instantiate(winScreen, new Vector3(0, playerOneCamera.position.y,0), Quaternion.identity);
                t.gameObject.layer = 8;

            }
            else
            {
                Instantiate(confeti, new Vector3(0, playerTwo.position.y + 3f, 1), Quaternion.identity);
                Transform t = Instantiate(loseScreen, new Vector3(0, playerOneCamera.position.y, 0), Quaternion.identity);
                t.gameObject.layer = 8;
                t = Instantiate(winScreen, new Vector3(0, playerTwoCamera.position.y, 0), Quaternion.identity);
                t.gameObject.layer = 9;
            }
        }

        public void StartNewGame()
        {
            SceneManager.LoadScene("Geo");
            return;            
        }
    }

}