using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    private float elapsedTime; //경과시간
    public bool isGameOver = false;

    private void Start()
    {
       
    }

    private void Update()
    {
        if (isGameOver)
        {
            return;
        }

        this.elapsedTime += Time.deltaTime;

        if(this.elapsedTime > 1f)
        {
            CreatArrow();
            this.elapsedTime = 0f;
        }
    }

    private void CreatArrow()
    {
        GameObject arrowGo = Object.Instantiate(arrowPrefab);
        float randomPosX = Random.Range(-8.0f, 8.0f);
        arrowGo.transform.position = new Vector3(randomPosX, 10f, 0);
    }
}
