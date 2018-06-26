using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CChamber
{
    // 주변 방향 정보 리스트
    public List<Vector2Int> NextChamberPosition { get; private set; }
    // 현재 Chamber 이전의 Chamber 위치 저장, 각 Chamber는 이전 Chamber를 많아야 1개까지만 존재
    public Vector2Int PrevChamberPosition { get; set; }
    // Chamber의 종류
    public EChamberType ChamberType { get; set; }

    public CChamber(EChamberType type, Vector2Int position)
    {
        NextChamberPosition = new List<Vector2Int>();
        PrevChamberPosition = position;
        ChamberType = type;
    }
}
