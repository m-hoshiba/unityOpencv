using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using OpenCvSharp;


public class testopencv : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Mat src = new Mat("C:/Users/moto/Documents/New Unity Project/Assets/su-152_1920x1080_noc_ru.jpg", ImreadModes.GrayScale);
        // Mat src = Cv2.ImRead("lenna.png", ImreadModes.GrayScale);
        Mat dst = new Mat();

        Cv2.Canny(src, dst, 50, 200);
        using (new Window("src image", src))
        using (new Window("dst image", dst))
        {
            Cv2.WaitKey();

        }

        // Update is called once per frame
		
	}
}
