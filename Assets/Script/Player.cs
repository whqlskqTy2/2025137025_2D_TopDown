using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 이동 속도 (기본값 2f)
    float moveSpeed = 2f;

    // 각 방향별 스프라이트 (인스펙터에서 할당)
    [SerializeField] Sprite spriteUp;
    [SerializeField] Sprite spriteDown;
    [SerializeField] Sprite spriteLeft;
    [SerializeField] Sprite spriteRight;
    [SerializeField] TextMeshProUGUI scoreText;

    // 물리 및 렌더링 컴포넌트
    Rigidbody2D rb;          // Rigidbody2D: 물리 이동 제어용
    SpriteRenderer sR;       // SpriteRenderer: 캐릭터 이미지 표시용

    // 입력과 속도
    Vector2 input;           // 방향키 입력값
    Vector2 velocity;        // 실제 이동 벡터

    int score = 0;

    

    private void Awake()
    {
        // 컴포넌트 가져오기
        rb = GetComponent<Rigidbody2D>();          // Rigidbody2D 컴포넌트 참조
        sR = GetComponent<SpriteRenderer>();       // SpriteRenderer 컴포넌트 참조

        // Rigidbody2D를 키네마틱 모드로 설정 (물리 힘의 영향을 받지 않음)
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
    private void Update()
    {
        // 방향키 입력값 받아오기 (수평: 좌/우, 수직: 상/하)
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical"); // 방향키 상하좌우 or WASD로 움직이기 가능

        // 입력 방향을 정규화하고 이동 속도 곱하기
        velocity = input.normalized * moveSpeed;

        // 입력이 일정 이상일 경우 (0.01f보다 클 때만 실행, 미세한 입력 무시)
        if (input.sqrMagnitude > .01f)
        {
            // 수평 이동이 수직보다 큰 경우 → 좌우 방향 처리
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                if (input.x > 0)
                    sR.sprite = spriteRight;  // 오른쪽 이동 시 spriteRight 사용
                else if (input.x < 0)
                    sR.sprite = spriteLeft;   // 왼쪽 이동 시 spriteLeft 사용
            }
            else
            {
                if (input.y > 0)
                    sR.sprite = spriteUp;     // 위로 이동 시 spriteUp 사용
                else
                    sR.sprite = spriteDown;   // 아래로 이동 시 spriteDown 사용
            }
        }
    }

    // Rigidbody를 사용한 실제 이동은 FixedUpdate에서 처리
    private void FixedUpdate()
    {
        // 현재 위치에 속도를 곱해서 이동
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            score += collision.GetComponent<ItemObject>().GetPoint();
            scoreText.text = score.ToString();
            Destroy(collision.gameObject);
        }
    }

}
