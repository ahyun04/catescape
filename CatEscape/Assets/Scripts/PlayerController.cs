using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float radius = 1f;
    public int maxHp = 100;
    public int hp;
    public GameDirector gameDirector;
    private bool isGameOver = false;  
    private float elapsedTime = 0f;   
    
    private float remainingTime = 30f;

    void Start()
    {
        this.maxHp = 100;
        this.hp = 100;
        

        Debug.Log($"�÷��̾��� ü�� : {this.hp}");
    }

    void Update()
    {
        if (isGameOver) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("�������� �̵�");
            this.transform.Translate(-1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("���������� �̵�");
            this.transform.Translate(1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("���� �̵�");
            this.transform.Translate(0, 1 , 0);
        }

        elapsedTime += Time.deltaTime;
        remainingTime -= Time.deltaTime;
        gameDirector.UpdateTimer(remainingTime);

        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            EndGame();
            return;
        }

        
    }

    private void OnDrawGizmos()
    {
        GizmosExtensions.DrawWireArc(this.transform.position, 360, radius);
    }

    public void HitDamage(float damage)
    {
        this.hp -= (int)damage;
        Debug.Log($"���ظ� �޾ҽ��ϴ�. {this.hp}/{this.maxHp}");

        float fillAmount = (float)this.hp / this.maxHp;
        this.gameDirector.UpdateHpGauge(fillAmount);

        if (this.hp <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        isGameOver = true;
        //gameDirector.ShowGameOver(score);
    }
}
