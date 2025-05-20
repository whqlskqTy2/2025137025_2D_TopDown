using System.Collections;
using System.Collections.Generic;
using UnityEngine;  // Unity ���� Ŭ���� �� �Լ� ����� ���� ���ӽ����̽�

// ItemObject Ŭ���� ����, MonoBehaviour�� ��ӹ޾� Unity ������Ʈ�� ����
public class ItemObject : MonoBehaviour
{
    // �ν����Ϳ��� ������ �� �ֵ��� ScriptableObject Ÿ���� data ������ ����ȭ
    [SerializeField] ItemSO data;  // Inspector �巡��

    // �ܺο��� data ���� point ���� ������ �� �ִ� �޼���
    public int GetPoint()
    {
        return data.point;  // ItemSO�� point �� ��ȯ
    }
}
