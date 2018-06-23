using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CChamber
{
    // 주변 방향 정보 리스트
    public List<Vector2Int> NextChamberPosition { get; private set; }
    // Chamber의 종류
    public EChamberType ChamberType { get; set; }

    public CChamber(EChamberType type)
    {
        NextChamberPosition = new List<Vector2Int>();
        ChamberType = type;
    }
}
