using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookAtCamera : MonoBehaviour
{
    [SerializeField] private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        if(cam == null)
        {
            cam = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam.transform);
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
