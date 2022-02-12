using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;
    public float explosionRadius = 5f;
    GameManager gm;
    public int scoreAmount = 3;

    public void CreateSlicedFruit()
    {
        GameObject inst = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        Rigidbody[] rbOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rigidbody in rbOnSliced)
        {
            rigidbody.transform.rotation = Random.rotation;
            rigidbody.AddExplosionForce(Random.Range(500, 1000), inst.transform.position, explosionRadius);
        }

        gm.IncreaseScore(scoreAmount);
        gm.PlayRandomSliceSound();  // 사운드 출력

        Destroy(inst, 5f);
        Destroy(gameObject);
    }

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Blade b = other.GetComponent<Blade>();

        if(!b)
        {
            return;
        }
        CreateSlicedFruit();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateSlicedFruit();
        }        
    }
}
