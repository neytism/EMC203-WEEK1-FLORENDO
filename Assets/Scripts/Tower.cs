using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Material normal;
    public Material near;
    public Material triggered;

    public float towerRange = 5f;
    public float viewAngleRange = 180f;

    public MeshRenderer[] meshRenderers;

    public bool enableDebug = true;
    
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

        if (IsPlayerInRange() && IsPlayerSeen())
        {
            Debug.Log("Player Seen!");
            _player.GetComponent<PlayerMovement>().ReturnToStartingPoint();
        }
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
        float dotProduct = DotProduct(NormalizeVector(directionToPlayer), transform.forward);
        
        return dotProduct > ConvertViewAngle(viewAngleRange);
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

    private float Magnitude(Vector3 v)
    {
        return Mathf.Sqrt(Mathf.Pow(v.x, 2) + Mathf.Pow(v.y, 2) + Mathf.Pow(v.z, 2));
    }

    private Vector3 NormalizeVector(Vector3 v)
    {
        float mag = Magnitude(v);

        v.x /= mag;
        v.y /= mag;
        v.z /= mag;
        
        return v;
    }

    private float ConvertViewAngle(float angle)
    {
        return Mathf.Cos(angle * 0.5f * Mathf.Deg2Rad);
    }
    
    private void OnDrawGizmos()
    {
        if (!enableDebug) return;
        
        Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);
        Gizmos.color = transparentRed;
        Gizmos.DrawSphere(transform.position, towerRange);
        
        if (_player != null )Gizmos.DrawLine(transform.position, _player.position);
    }
}
