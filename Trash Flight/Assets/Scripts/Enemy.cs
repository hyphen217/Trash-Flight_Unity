using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -7f;

    [SerializeField]
    private float hp = 1f;


    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

    // 적과 미사일 충돌 시 데미지 적용
    private void OnTriggerEnter2D(Collider2D other)//isTrigger가 체크되어 있으면 이 메서드를 사용. 체크 해제 시 OnCollisionEnter2D 사용
    {
        if (other.gameObject.tag == "Weapon") // Weapon 태그의 오브젝트를 찾음
        {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage;
            if (hp <= 0)
            {
                if (gameObject.tag == "Boss")
                {
                    GameManager.instance.SetVictory();
                }

                Destroy(gameObject);
                Instantiate(coin, transform.position, Quaternion.identity);
            }
            Destroy(other.gameObject); // 적과 충돌 시 미사일 삭제

        }
    }
}
