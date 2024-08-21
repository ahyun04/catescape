using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private float speed = 10f;
    public float radius = 1f;
    public Transform player;
    public int damage = 10;
    private GameDirector gameDirector;

    private void Start()
    {
        this.player = GameObject.Find("player").transform;
        this.damage = 10;
        Debug.Log($"화살의 공격력 : {this.damage}");
    }

    void Update()
    {
        Vector3 movement = Vector3.down * speed * Time.deltaTime;
        this.transform.Translate(movement);

        if (this.transform.position.y <= -10f)
        {
            Destroy(this.gameObject);
        }

        bool isCollided = CheckCollsion();
        if (isCollided)
        {
            Object.Destroy(this.gameObject);
        }

        if (this.transform.position.y <= -6.36f)
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        GizmosExtensions.DrawWireArc(this.transform.position, 360, radius);
    }

    private bool CheckCollsion()
    {
        float distance = Vector3.Distance(player.position, this.transform.position);
        PlayerController playerController = this.player.gameObject.GetComponent<PlayerController>();
        float sumRadius = this.radius + playerController.radius;

        if (distance <= sumRadius)
        {
            playerController.HitDamage(this.damage);
            return true;
        }
        else
        {
            return false;
        }
    }
}
