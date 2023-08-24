using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Material normal;
    public Material near;
    public Material triggered;

    public float towerRange = 5f;
    public float viewRange = 0.25f;

    public MeshRenderer[] meshRenderers;
    
    private Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        ColorChanger();
    }

    private void ColorChanger()
    {
        if (meshRenderers.Length == 0) return;
        
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.material = (IsPlayerInRange() && IsPlayerSeen()) ? triggered : IsPlayerInRange() ? near : normal;
        }
    }

    private bool IsPlayerInRange()
    {
        float distance = Distance(transform.position, _player.position);
        return distance < towerRange;
    }

    private bool IsPlayerSeen()
    {
        Vector3 directionToPlayer = _player.position - transform.position;
        float dotProduct = DotProduct(directionToPlayer.normalized, transform.forward);

        return dotProduct > viewRange;
    }

    private float Distance(Vector3 firstPos, Vector3 secondPos)
    {
        float xDifference = firstPos.x - secondPos.x;
        float yDifference = firstPos.y - secondPos.y;
        float zDifference = firstPos.z - secondPos.z;
        
        return Mathf.Sqrt(Mathf.Pow((xDifference), 2) + Mathf.Pow((yDifference), 2) + Mathf.Pow((zDifference), 2));
    }

    private float DotProduct(Vector3 firstPos, Vector3 secondPos)
    {
        float xProduct = firstPos.x * secondPos.x;
        float yProduct = firstPos.y * secondPos.y;
        float zProduct = firstPos.z * secondPos.z;
        
        return xProduct + yProduct + zProduct;
    }
    
    
}
