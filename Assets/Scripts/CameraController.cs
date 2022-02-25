using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Transform target;
    public Transform Background;
    public float minHeight, maxHeight;
    private float lastXPos;
    public bool stopFollow;



      private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        lastXPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
       if(!stopFollow)
        {
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);
            float amountToMoveX = transform.position.x - lastXPos;

            Background.position = Background.position + new Vector3(amountToMoveX, 0f, 0f);

            lastXPos = transform.position.x;
        }
   
    }
}
