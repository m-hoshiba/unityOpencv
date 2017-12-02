using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour {

    private string directryPath = "Assets/Screenshot/";
    [SerializeField] private string FileName = "screenshot.png";
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ScreenCapture.CaptureScreenshot(directryPath + FileName);
        }

    }
}
