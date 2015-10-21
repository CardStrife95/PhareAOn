using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public Transform characterTransform;
    public Transform position;
    // Update is called once per frame

    void Start()
    {
        //position = new Transform();
    }

    void Update()
    {
        this.transform.localPosition = characterTransform.localPosition;
        this.transform.localPosition += new Vector3(0, 3, -10);
    }
}
