using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosView : MonoBehaviour {
    public Text position;
    private float x = 0;
    private float y = 0;
    private float z = 0;
    [SerializeField] private Transform target;


    // Use this for initialization
    void Start () {
        RefreshPosition();

    }

    // Update is called once per frame
    void Update () {
        x = target.position.x;
        y = target.position.y;
        z = target.position.z;
        RefreshPosition();
    }

    void RefreshPosition()
    {
        position.text = "POSITION X : " + x + " Y : " + y + " Z : " + z;

    }

}
