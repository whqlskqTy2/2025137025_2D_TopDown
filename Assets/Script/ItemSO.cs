using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 메뉴에 ScriptableObject를 생성할 수 있는 옵션 추가
// "Game/Item" 경로에 "NewItem"이라는 이름으로 생성됨
[CreateAssetMenu(menuName = "Game/Item", fileName = "NewItem")]
public class ItemSO : ScriptableObject
{
    // 인스펙터 창에서 point 변수 위에 "Score Value"라는 헤더 텍스트를 표시
    [Header("Score Value")]

    // 점수 값을 저장하는 변수, 기본값은 10
    public int point = 10;
}


