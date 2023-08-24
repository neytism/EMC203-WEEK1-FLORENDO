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
        float distance = Distance(transform, player);

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

    private float Distance(Transform firstPos, Transform secondPos)
    {
        return Mathf.Sqrt(Mathf.Pow((firstPos.position.x - secondPos.position.x), 2) + Mathf.Pow((firstPos.position.y - secondPos.position.y), 2) + Mathf.Pow((firstPos.position.z - secondPos.position.z), 2));
    }
}
