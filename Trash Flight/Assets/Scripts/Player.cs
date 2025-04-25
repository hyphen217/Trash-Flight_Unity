using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;


    //===미사일 챕터===
    [SerializeField]
    private GameObject[] weapons;
    private int weaponIndex = 0; // 무기 업그레이드

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.05f;
    private float lastShotTime = 0f;

    //===============

    void Update()
    {
        // float horizontalInput = Input.GetAxisRaw("Horizontal");// 横移動値
        // float verticalInput = Input.GetAxisRaw("Vertical"); // 縦移動値
        // Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f); // キーボード入力値
        // transform.position += moveTo * moveSpeed * Time.deltaTime;

        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        // //キーボード：左入力時
        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     transform.position -= moveTo;
        // }
        // //キーボード：右入力時
        // else if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     transform.position += moveTo;
        // }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Input.mousePosition:오래된 방법. Mouse.current.position.ReadValue():최신 방법.
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f); // Mathf.Clamp: 지정한 값이 min보다 작으면 min값 적용, max보다 크면 max값 적용. 그 사이 값이면 그대로 적용.
        transform.position = new Vector3(toX, transform.position.y, transform.position.z); // x만 마우스 위치로 받음 / y&z는 플레이어의 현재 위치(이동x)

        if (GameManager.instance.isGameOver == false && GameManager.instance.isWin == false)
        {
            Shoot();
        }
    }

    //===미사일 챕터===
    void Shoot()
    {

        if (Time.time - lastShotTime > shootInterval)
        {
            //어떤 게임 오브젝트를 만들지, 어떤 위치에 만들지, 회전을 어떻게 할지
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity); // Quaternion.identity: 회전 없이 위로 올라감.
            lastShotTime = Time.time;
        }
    }
    //===============

    // 플레이어와 적의 충돌
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            GameManager.instance.SetGameOver();
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Coin")
        {
            GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        }
    }

    public void Upgrade()
    {
        weaponIndex += 1;
        if (weaponIndex >= weapons.Length)
        {
            weaponIndex = weapons.Length - 1;
        }
    }
}
