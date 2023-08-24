using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Material normal;
    public Material triggered;

    public float towerRange = 5f;
    
    private Transform _player;
    private MeshRenderer _meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject.transform;
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDistanceChecker();
    }

    private void PlayerDistanceChecker()
    {
        _meshRenderer.material = IsPlayerInRange() ? triggered : normal;
    }

    private bool IsPlayerInRange()
    {
        float distance = Distance(transform.position, _player.position);
        return distance < towerRange;
    }

    private float Distance(Vector3 firstPos, Vector3 secondPos)
    {
        float xDifference = firstPos.x - secondPos.x;
        float yDifference = firstPos.y - secondPos.y;
        float zDifference = firstPos.z - secondPos.z;
        
        return Mathf.Sqrt(Mathf.Pow((xDifference), 2) + Mathf.Pow((yDifference), 2) + Mathf.Pow((zDifference), 2));
    }
}
