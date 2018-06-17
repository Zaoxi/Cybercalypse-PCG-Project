using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDungeonDrivenContentsGenerator : MonoBehaviour {
    // 상수
    const float TILE_LENGTH = 0.16f;

    // 필드
    private Dictionary<Vector2, ETileType> tileData;
    private List<Chamber> chamberList;
    private List<Passage> passageList;


    void Awake()
    {
        tileData = new Dictionary<Vector2, ETileType>();
    }


}

// 생성할 타입의 종류
public enum ETileType
{
    Flat, Uphill, Downhill, Foothold, Ceiling, Wall, Stuff, Empty, Portal
}
// 순서대로 평지, 오르막길, 내리막길, 발판, 천장, 벽, 쓸모없는 공간, 플레이어가 다닐 수 있는 빈 공간, 포탈

// Chamber에서 다른 Chamber로 향할 수 있는 방향
public enum EPassageDirection
{
    Right, Left, Up, Down, RightUp, LeftUp, RightDown, LeftDown
}



// 방
public class Chamber
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    private Dictionary<EPassageDirection, Passage> passageList;

    public Chamber(int width, int height)
    {
        Width = width;
        Height = height;

        passageList = new Dictionary<EPassageDirection, Passage>();
    }
}

// Chamber와 Chamber를 이어주는 통로
public class Passage
{
    // 통로 출발 지점과
    public Vector3 StartPos { get; private set; }
    public Vector3 EndPos { get; private set; }
    public float Interval { get; private set; }

    public Passage(Vector3 start, Vector3 end, float interval)
    {
        StartPos = start;
        EndPos = end;
        Interval = interval;
    }
}