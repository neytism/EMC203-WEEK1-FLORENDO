using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Material normal;
    public Material triggered;

    public float towerRange = 5f;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        IsPlayerInRange();
    }

    private void IsPlayerInRange()
    {
        float distance = Mathf.Sqrt(Mathf.Pow((transform.position.x - player.position.x), 2) + Mathf.Pow((transform.position.z - player.position.z), 2));

        if (distance < towerRange)
        {
            Debug.Log("IsNear");
            GetComponent<MeshRenderer>().material = triggered;
        }
        else
        {
            Debug.Log("IsFar");
            GetComponent<MeshRenderer>().material = normal;
        }
    }
}
