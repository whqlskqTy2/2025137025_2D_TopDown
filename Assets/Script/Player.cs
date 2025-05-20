using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �̵� �ӵ� (�⺻�� 2f)
    float moveSpeed = 2f;

    // �� ���⺰ ��������Ʈ (�ν����Ϳ��� �Ҵ�)
    [SerializeField] Sprite spriteUp;
    [SerializeField] Sprite spriteDown;
    [SerializeField] Sprite spriteLeft;
    [SerializeField] Sprite spriteRight;
    [SerializeField] TextMeshProUGUI scoreText;

    // ���� �� ������ ������Ʈ
    Rigidbody2D rb;          // Rigidbody2D: ���� �̵� �����
    SpriteRenderer sR;       // SpriteRenderer: ĳ���� �̹��� ǥ�ÿ�

    // �Է°� �ӵ�
    Vector2 input;           // ����Ű �Է°�
    Vector2 velocity;        // ���� �̵� ����

    int score = 0;

    

    private void Awake()
    {
        // ������Ʈ ��������
        rb = GetComponent<Rigidbody2D>();          // Rigidbody2D ������Ʈ ����
        sR = GetComponent<SpriteRenderer>();       // SpriteRenderer ������Ʈ ����

        // Rigidbody2D�� Ű�׸�ƽ ���� ���� (���� ���� ������ ���� ����)
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
    private void Update()
    {
        // ����Ű �Է°� �޾ƿ��� (����: ��/��, ����: ��/��)
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical"); // ����Ű �����¿� or WASD�� �����̱� ����

        // �Է� ������ ����ȭ�ϰ� �̵� �ӵ� ���ϱ�
        velocity = input.normalized * moveSpeed;

        // �Է��� ���� �̻��� ��� (0.01f���� Ŭ ���� ����, �̼��� �Է� ����)
        if (input.sqrMagnitude > .01f)
        {
            // ���� �̵��� �������� ū ��� �� �¿� ���� ó��
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                if (input.x > 0)
                    sR.sprite = spriteRight;  // ������ �̵� �� spriteRight ���
                else if (input.x < 0)
                    sR.sprite = spriteLeft;   // ���� �̵� �� spriteLeft ���
            }
            else
            {
                if (input.y > 0)
                    sR.sprite = spriteUp;     // ���� �̵� �� spriteUp ���
                else
                    sR.sprite = spriteDown;   // �Ʒ��� �̵� �� spriteDown ���
            }
        }
    }

    // Rigidbody�� ����� ���� �̵��� FixedUpdate���� ó��
    private void FixedUpdate()
    {
        // ���� ��ġ�� �ӵ��� ���ؼ� �̵�
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
