using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] levelPrefabs;
    private GameObject currentLevel;
    private int difficulty = 0;
    [SerializeField] private GameObject playerPrefab;
    private GameObject player;

    void Start()
    {
        if (MainManager.Instance != null) {
            currentLevel = levelPrefabs[Mathf.Clamp(MainManager.Instance.map, 0, levelPrefabs.Length)];
            difficulty = MainManager.Instance.difficulty;
        } else {
            print("Error: MainManager instance not found. Data cannot be loaded.");
        }
        if(currentLevel) {
            Instantiate(currentLevel, Vector3.zero, Quaternion.identity);
        }
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlayer(int primary = 1, int secondary = 1, int equipment = 1) {
        if(player) {
            print("Error: player already exists; duplicate player character cannot be spawned");
            return;
        }
        Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        // Later: set player's Primary, Secondary, and Equipment
    }
}