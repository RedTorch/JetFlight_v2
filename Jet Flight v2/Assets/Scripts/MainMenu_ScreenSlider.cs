using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles the vertical layout buttons in the main menu (which switch between menu screens and quit the game)

public class MainMenu_ScreenSlider : MonoBehaviour
{
    [SerializeField] private Transform screenSliderTransform;
    private float[] slidePositions = {-630f, 0f, 630f};
    private float currPositionVertical = 0f;
    private float desiredPositionVertical = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateSliderPosition();
    }

    private void updateSliderPosition() {
        if(currPositionVertical == desiredPositionVertical) {
            return;
        }
        currPositionVertical = Mathf.Lerp(currPositionVertical, desiredPositionVertical, 10f*Time.deltaTime);
        screenSliderTransform.localPosition = new Vector3(0f, currPositionVertical, 0f);
    }

    public void SetDesiredPosition(int index) {
        desiredPositionVertical = slidePositions[Mathf.Clamp(index,0,slidePositions.Length-1)];
    }

    public void QuitGame() {
        Application.Quit();
    }
}
