using System.Collections;
using System.Collections.Generic;
using UnityEngine;  // Unity 관련 클래스 및 함수 사용을 위한 네임스페이스

// ItemObject 클래스 정의, MonoBehaviour를 상속받아 Unity 컴포넌트로 동작
public class ItemObject : MonoBehaviour
{
    // 인스펙터에서 설정할 수 있도록 ScriptableObject 타입의 data 변수를 직렬화
    [SerializeField] ItemSO data;  // Inspector 드래그

    // 외부에서 data 안의 point 값을 가져올 수 있는 메서드
    public int GetPoint()
    {
        return data.point;  // ItemSO의 point 값 반환
    }
}
