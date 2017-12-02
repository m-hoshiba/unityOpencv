using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using OpenCvSharp;
using UnityEngine.UI;

using System.IO;




public class Test : MonoBehaviour {
    private new Camera camera;
    
    [SerializeField] private RenderTexture renderTexture;
    [SerializeField] private Image image;
    private Text text;

    private string tempImagePath { get
        {
            return Application.dataPath + "/tempImage.png";
        }
    }
    // Use this for initialization
    void Start () {
        camera = gameObject.GetComponent<Camera>();

        //targetTexture = camera.targetTexture;
        //RenderTexture renderTexture = camera.targetTexture;
        //RenderBuffer renderBuffer = renderTexture.colorBuffer;

        /*
        Mat src = new Mat(texturePath, ImreadModes.GrayScale);
        // Mat src = Cv2.ImRead("lenna.png", ImreadModes.GrayScale);
        Mat dst = new Mat();

        Cv2.Canny(src, dst, 50, 200);
        using (new Window("src image", src))
        using (new Window("dst image", dst))
        {
            Cv2.WaitKey();
        }
        */
    }

    
	// Update is called once per frame
	void Update () {
        camera.targetTexture = renderTexture;

		RenderTexture tex = renderTexture;
        Texture2D targetTexture = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);

        RenderTexture.active = camera.targetTexture;
        camera.Render();

        targetTexture.ReadPixels(new UnityEngine.Rect(0, 0, tex.width, tex.height), 0, 0);
        targetTexture.Apply();

        savePng(targetTexture);

        image.sprite = Sprite.Create(targetTexture, new UnityEngine.Rect(0, 0, tex.width, tex.height), Vector2.zero);


        
        Mat src = new Mat(tempImagePath, ImreadModes.Color);
        //Mat dst = new Mat();

        using (new Window("image", src))
        {

        }


        RenderTexture.active = null;
        camera.targetTexture = null;

        
	}

    void convertTexture2DtoMat(RenderTexture tex, Texture2D targetTexture)
    {
        const int size = 4;
        Mat mat = new Mat(tex.width, tex.height, MatType.CV_8UC4);
        int[] data = new int[tex.width * tex.height * size];
        Color32[] colors = targetTexture.GetPixels32();

        for(int j=0; j<tex.height; ++j)
        {
            for(int i=0; i<tex.width; ++i)
            {
                Color32 col = colors[i + tex.width * j];
                data[size * (i + tex.width * j)] = col.a;
                data[size * (i + tex.width * j) + 1] = col.r;
                data[size * (i + tex.width * j) + 2] = col.g;
                data[size * (i + tex.width * j) + 3] = col.b;
            }
        }

        Mat src = new Mat(tex.width, tex.height, MatType.CV_8UC4, data);
    }

    void savePng(Texture2D tex)
    {
        byte[] bytes = tex.EncodeToPNG();

        File.WriteAllBytes(tempImagePath, bytes);
    }
    

   
}
