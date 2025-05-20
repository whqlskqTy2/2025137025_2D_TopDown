using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �޴��� ScriptableObject�� ������ �� �ִ� �ɼ� �߰�
// "Game/Item" ��ο� "NewItem"�̶�� �̸����� ������
[CreateAssetMenu(menuName = "Game/Item", fileName = "NewItem")]
public class ItemSO : ScriptableObject
{
    // �ν����� â���� point ���� ���� "Score Value"��� ��� �ؽ�Ʈ�� ǥ��
    [Header("Score Value")]

    // ���� ���� �����ϴ� ����, �⺻���� 10
    public int point = 10;
}


