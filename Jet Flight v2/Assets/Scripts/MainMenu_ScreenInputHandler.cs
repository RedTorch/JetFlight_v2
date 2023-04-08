using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_ScreenInputHandler : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPrimary(int val) {
        MainManager.Instance.primary = val;
    }

    public void SetSecondary(int val) {
        MainManager.Instance.secondary = val;
    }

    public void SetEquipment(int val) {
        MainManager.Instance.equipment = val;
    }

    public void SetMap(int val) {
        MainManager.Instance.map = val;
    }

    public void SetDifficulty(int val) {
        MainManager.Instance.difficulty = val;
    }

    public void AdvanceScene() {
        SceneManager.LoadScene("IngameScene");
    }
}
