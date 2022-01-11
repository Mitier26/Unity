using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBuilderScript : MonoBehaviour
{
    public GameObject obj;
    public Transform spawnPoint;

    public void BuildObject()
    {
        Instantiate(obj, spawnPoint.position, Quaternion.identity);
    }
}
