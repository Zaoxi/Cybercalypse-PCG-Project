using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public struct Chamber
{
    // 주변 방향 정보 리스트
    public HashSet<Vector2Int> NextChamberPosition { get; private set; }
    // Chamber의 종류
    public EChamberType ChamberType { get; private set; }

    public Chamber(EChamberType type)
    {
        NextChamberPosition = new HashSet<Vector2Int>();
        ChamberType = type;
    }

    public void SetChamberType(EChamberType type)
    {
        ChamberType = type;
    }
}
