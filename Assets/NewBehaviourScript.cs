using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 2f;

    public Vector3 direction;

    public GameObject gameObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // apply movement to player
        gameObj.transform.position += direction * speed;
    }
}
