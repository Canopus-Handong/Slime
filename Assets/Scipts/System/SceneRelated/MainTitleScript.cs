using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTitleScript : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    private SceneManager SM;

    private void Awake() {
        SM = new SceneManager();
        SM.LoadSceneName = "SampleScene";
    }

    private void Update() {
        if(Input.anyKey) {
            //make it that it plays an animation before changing the scene
            if(Input.GetKeyDown(KeyCode.Escape)) {
                SM.ExitGame();
            }
            else {
                SM.LoadScene();
            }
        }
    }
}
