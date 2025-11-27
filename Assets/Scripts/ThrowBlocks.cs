using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBlocks : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Camera;
    public GameObject Block;
    public float randNum;
    public Vector2 SpawnPos;
    
    void Start()
    {
        StartCoroutine(LauchBlocksWait());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator LauchBlocksWait()
    {
        yield return new WaitForSeconds(10f);
        while (true)
            {
                yield return new WaitForSeconds(3.5f);
                randNum = Random.Range(-3.7f, 3.7f);
                SpawnPos = new Vector2(Camera.transform.position.x - 12, randNum);
                Instantiate(Block, SpawnPos, Quaternion.identity);
            }
    }
}
