using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    //an array of fruit prefabs
    public GameObject[] fruitPrefabs;
    public playerCamera player;
    public TextMesh infoText;
    public float horizontalArea = 5f;
    public float spawnDuration = 3f;
    private float spawnTimer;
    private float resetTimer = 3f;
    public float gameTimer = 15f;

	// Use this for initialization
	void Start () {
        spawnTimer = spawnDuration;
	}

    // Update is called once per frame, 
    //this is what causes three fruits to spawn each time
    void Update() {
        if (gameTimer > 0) {
            gameTimer -= Time.deltaTime;

            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                spawnTimer = spawnDuration;

                for (int i = 0; i < 3; i++)
                {
                    GameObject fruit = Instantiate(fruitPrefabs[Random.Range(0, fruitPrefabs.Length)]);
                    fruit.transform.position = new Vector3(
                        Random.Range(-horizontalArea, horizontalArea),
                        0.5f,
                        0
                    );
                }
            }
            infoText.text = "Slash the fruits!\nTime: " + Mathf.Floor(gameTimer) + "\nScore: " + player.score;
        } else {
            infoText.text = "Game over! Score: " + player.score;
            //resets game
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        }
    } 
