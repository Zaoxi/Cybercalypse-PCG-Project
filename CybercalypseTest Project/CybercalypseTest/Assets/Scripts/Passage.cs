using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// Chamber와 Chamber를 이어주는 통로
public class Passage
{
    // 통로 출발 지점과 끝지점 좌표(상대좌표)
    public Vector2 StartLeftBottom { get; private set; }
    public Vector2 StartRightUp { get; private set; }

    public Vector2 EndLeftBottom { get; private set; }
    public Vector2 EndRightUp { get; private set; }

    public float Interval { get; private set; }

    public Chamber StartChamber { get; private set; }
    public Chamber EndChamber { get; private set; }

    public Passage(Vector2 startLeftBottom, Vector2 startRightUp)
    {
        StartLeftBottom = startLeftBottom;
        StartRightUp = startRightUp;

        LevelManager.instance.DungeonGenerator.RegisterPassageToList(this);
        // EndPos를 설정하고 그 지점을 기준으로 새로운 Chamber 생성
    }
    // 다음 경로와 현재 경로를 묶는 메소드
    public void CombinePassage(Passage dstPassage)
    {
        EndLeftBottom = dstPassage.StartLeftBottom;
        EndRightUp = dstPassage.StartRightUp;
    }
}