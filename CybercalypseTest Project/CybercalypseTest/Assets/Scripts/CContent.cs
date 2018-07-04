using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 생성될 맵에 배치될 구성요소를 저장하는 클래스
/// 구성요소의 TileType, 타일의 가로 수, 타일의 세로 수, 
/// 콜라이더 등의 컴포넌트가 적용된 구성요소의 프리팹을 저장
/// 고려하지 못한 변수가 존재하면 해당하는 변수를 추가
/// </summary>
public class CContent : MonoBehaviour {
    public ETileType tileType;
    public int numOfWidth, numOfHeight;
    public GameObject content;
}
