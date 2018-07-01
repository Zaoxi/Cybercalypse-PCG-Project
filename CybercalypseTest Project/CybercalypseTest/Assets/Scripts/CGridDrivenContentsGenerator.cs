using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CGridDrivenContentsGenerator : MonoBehaviour
{
    // 상대 좌표에 곱할 상수
    public const float TILE_LENGTH = 0.16f;
    // 해당하는 상대좌표에 어떤 종류의 타일이 배치되었는지 저장
    public Dictionary<Vector2Int, ETileType> TilePosition { get; private set; }
    // 그리드 사각형 내에 어떤 그리드에 어떤 Chamber가 위치하는지 저장
    public Dictionary<Vector2Int, CChamber> ChamberPosition { get; private set; }

    // 각 Chamber에 대한 공통 정보
    public int ChamberWidth { get; private set; }
    public int ChamberHeight { get; private set; }
    public int NumOfChamberInHorizontal { get; private set; }
    public int NumOfChamberInVertical { get; private set; }

    // 출발 지점의 Chamber 상대 좌표
    public Vector2Int StartChamber { get; private set; }
    // 도착 지점의 Chamber 상대 좌표
    public Vector2Int EndChamber { get; private set; }

    void Awake()
    {
        TilePosition = new Dictionary<Vector2Int, ETileType>();
        ChamberPosition = new Dictionary<Vector2Int, CChamber>();
    }

    /// <summary>
    /// 생성할 맵에 대한 최소 정보 입력(Chamber의 가로, 세로, Chamber의 가로 개수, Chamber의 세로 개수)
    /// </summary>
    public void InitGenerator(int width, int height, int numOfHorizontal, int numOfVertical)
    {
        ChamberWidth = width;
        ChamberHeight = height;
        NumOfChamberInHorizontal = numOfHorizontal;
        NumOfChamberInVertical = numOfVertical;
        makeNoneChamber();
        
    }

    // 맵 구동기 가동
    public void StartGenerator()
    {
        makeEssentialPath();
        Debug.Log("Essential Over");
        makeDummyPath(StartChamber);
        Debug.Log("Dummy Over");
    }
    private void Start()
    {
        InitGenerator(1, 1, 20, 20);
        StartGenerator();
    }

    /// <summary>
    /// 정해진 그리드 내에 None Chamber를 생성
    /// </summary>
    private void makeNoneChamber()
    {
        for (int i = 0; i < NumOfChamberInVertical; i++)
        {
            for (int j = 0; j < NumOfChamberInHorizontal; j++)
            {
                ChamberPosition.Add(new Vector2Int(i, j), new CChamber(EChamberType.None, new Vector2Int(i, j)));
            }
        }
    }

    /// <summary>
    /// 필수 경로를 생성
    /// </summary>
    private void makeEssentialPath()
    {
        Vector2Int currentPosition, nextPosition;
        Vector2Int[] adjacentPosition;
        // 필수 경로 시작 지점
        currentPosition = StartChamber = new Vector2Int(0, (int)Random.Range(0.0f, NumOfChamberInVertical));
        ChamberPosition[currentPosition].ChamberType = EChamberType.Essential;
        // 필수 경로 인접 지점
        adjacentPosition = getAdjacentPath(currentPosition, true);
        nextPosition = adjacentPosition[(int)Random.Range(0.0f, adjacentPosition.Length)];
        ChamberPosition[nextPosition].ChamberType = EChamberType.Essential;
        addFromCurrentToNextChamberPassage(currentPosition, nextPosition);
        currentPosition = nextPosition;
        // 그리드의 맨 오른쪽 위치 까지 진행
        while (currentPosition.x != NumOfChamberInHorizontal - 1)
        {
            adjacentPosition = getAdjacentPath(currentPosition, true);

            nextPosition = adjacentPosition[(int)Random.Range(0.0f, adjacentPosition.Length)];
            ChamberPosition[nextPosition].ChamberType = EChamberType.Essential;
            addFromCurrentToNextChamberPassage(currentPosition, nextPosition);
            currentPosition = nextPosition;
        }
        // 도착 지점 설정
        EndChamber = currentPosition;
    }

    /// <summary>
    /// 해당 좌표의 근접한 위치의 상대 좌표 배열을 반환
    /// </summary>
    /// <param name="path"> 근접한 위치의 좌표를 구할 기준 좌표 </param>
    /// <param name="isEssential"> 필수 경로의 근접좌표를 구하는가? </param>
    /// <returns> 근접한 좌표 배열 </returns>
    private Vector2Int[] getAdjacentPath(Vector2Int path, bool isEssential)
    {
        List<Vector2Int> adjacentList = new List<Vector2Int>();
        List<Vector2Int> availableList = new List<Vector2Int>();
        // 필수 경로가 아닌 경우에는 역으로 이동하는 경로도 고려
        if (!isEssential)
        {
            adjacentList.Add(new Vector2Int(path.x - 1, path.y)); // left
        }
        adjacentList.Add(new Vector2Int(path.x, path.y + 1)); //up
        adjacentList.Add(new Vector2Int(path.x, path.y - 1)); // down
        adjacentList.Add(new Vector2Int(path.x + 1, path.y)); // right

        adjacentList.ForEach(delegate (Vector2Int adjPath)
        {
            if (ChamberPosition.ContainsKey(adjPath) && ChamberPosition[adjPath].ChamberType == EChamberType.None)
            {
                availableList.Add(adjPath);
            }
        });

        return availableList.ToArray();
    }

    /// <summary>
    /// start Chamber와 end Chamber를 이어주는 메소드, 두 Chamber는 상대좌표 거리가 1만큼 차이나야 한다.
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    private void addFromCurrentToNextChamberPassage(Vector2Int start, Vector2Int end)
    {
        ChamberPosition[start].NextChamberPosition.Add(end);
        ChamberPosition[end].PrevChamberPosition = start;
    }

    /// <summary>
    /// 생성된 필수 경로를 기준으로 더미 경로를 생성한다.
    /// </summary>
    /// <param name="start"></param>
    private void makeDummyPath(Vector2Int start)
    {
        // 해당 Chamber가 필수 경로 상의 Chamber인 경우
        if (ChamberPosition[start].ChamberType == EChamberType.Essential && ChamberPosition[start].NextChamberPosition.Count != 0)
        {
            Debug.Log(start);
            // 다음 필수경로를 대상으로 실행
            makeDummyPath(ChamberPosition[start].NextChamberPosition[0]);
        }

        int possibility = (int)Random.Range(0.0f, 5.0f);
        Vector2Int[] adjacentChambers = getAdjacentPath(start, false);

        // 인접한 Chamber가 존재하지 않는 경우
        if (adjacentChambers.Length == 0)
        {
            return;
        }
        int index = (int)Random.Range(0.0f, adjacentChambers.Length);
        ChamberPosition[adjacentChambers[index]].ChamberType = EChamberType.Dummy;
        addFromCurrentToNextChamberPassage(start, adjacentChambers[index]);

        Debug.Log(adjacentChambers[index]);
        // 40%의 확률로 길이 확장
        if (possibility == 0 || possibility == 1 || possibility == 2)
        {
            makeDummyPath(adjacentChambers[index]);
        }  // 40% 확률로 새로운 길 분열
        else if (possibility == 3)
        {
            makeDummyPath(adjacentChambers[index]);
            makeDummyPath(start);
        }
    }
}
