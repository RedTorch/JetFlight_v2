using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] levelPrefabs;
    private GameObject currentLevel;
    private int difficulty = 0;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}