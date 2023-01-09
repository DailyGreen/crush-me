using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] Vector3 dir;
    float speed = 5.0f;

    void Update()
    {
        Move();
    }

    void Move()
    {
        dir = NetworkMng.I.EnemyPlayerTr.position - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform == NetworkMng.I.EnemyPlayerTr)
        {
            Destroy(gameObject);
            Debug.Log("미사일 적중");
        }
    }
}
