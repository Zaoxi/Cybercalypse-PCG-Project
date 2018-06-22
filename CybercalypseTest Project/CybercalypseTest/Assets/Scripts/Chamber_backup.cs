//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Random = UnityEngine.Random;


//// 방
//public class Chamber
//{
//    const int ESSENTIAL_MINIMUM_PASSAGE = 2;
//    const int ADJACENT_MINIMUM_PASSAGE = 1;

//    public float Width { get; private set; }
//    public float Height { get; private set; }

//    public Vector2 LeftBottom { get; private set; }
//    public Vector2 RightTop { get; private set; }

//    public List<Passage> PassageList { get; private set; }

//    public Chamber(Vector2 leftBottom, Vector2 rightTop)
//    {
//        LeftBottom = leftBottom;
//        RightTop = rightTop;

//        Width = Mathf.Abs(rightTop.x - leftBottom.x);
//        Height = Mathf.Abs(rightTop.y - leftBottom.y);

//        PassageList = new List<Passage>();

//        LevelManager.instance.DungeonGenerator.RegisterChamberToList(this);
//    }

//    private void generatePassage(EPassageDirection direction)
//    {
//        Vector2 startLeftBottom;
//        Vector2 startRightUp;

//        float intervalOfWidth = Width / 3;
//        float intervalOfHeight = Height / 3;

//        if (direction == EPassageDirection.Down)
//        {
//            startLeftBottom = new Vector2(Random.Range(LeftBottom.x + intervalOfWidth, RightTop.x - intervalOfWidth), LeftBottom.y);
//            startRightUp = new Vector2(startLeftBottom.x + intervalOfWidth, startLeftBottom.y);
//        }
//        else if (direction == EPassageDirection.Up)
//        {
//            startLeftBottom = new Vector2(Random.Range(LeftBottom.x + intervalOfWidth, RightTop.x - intervalOfWidth), RightTop.y);
//            startRightUp = new Vector2(startLeftBottom.x + intervalOfWidth, startLeftBottom.y);
//        }
//        else if (direction == EPassageDirection.Left)
//        {
//            startLeftBottom = new Vector2(LeftBottom.x, Random.Range(LeftBottom.y + intervalOfHeight, RightTop.y - intervalOfHeight));
//            startRightUp = new Vector2(startLeftBottom.x, startLeftBottom.y + intervalOfHeight);
//        }
//        else if (direction == EPassageDirection.Right)
//        {
//            startLeftBottom = new Vector2(RightTop.x, Random.Range(LeftBottom.y + intervalOfHeight, RightTop.y - intervalOfHeight));
//            startRightUp = new Vector2(startLeftBottom.x, startLeftBottom.y + intervalOfHeight);
//        }
//        else if (direction == EPassageDirection.LeftUp)
//        {
//            startRightUp = new Vector2(LeftBottom.x, Random.Range(RightTop.y - intervalOfHeight, RightTop.y));
//            startLeftBottom = new Vector2(startRightUp.x, startRightUp.y - intervalOfHeight);
//        }
//        else if (direction == EPassageDirection.LeftDown)
//        {
//            startLeftBottom = new Vector2(LeftBottom.x, Random.Range(LeftBottom.y - intervalOfHeight, LeftBottom.y));
//            startRightUp = new Vector2(startLeftBottom.x, startLeftBottom.y + intervalOfHeight);
//        }
//        else if (direction == EPassageDirection.RightUp)
//        {
//            startRightUp = new Vector2(RightTop.x, Random.Range(RightTop.y - intervalOfHeight, RightTop.y));
//            startLeftBottom = new Vector2(startRightUp.x, startRightUp.y - intervalOfHeight);
//        }
//        else if (direction == EPassageDirection.RightDown)
//        {
//            startLeftBottom = new Vector2(RightTop.x, Random.Range(LeftBottom.y, LeftBottom.y + intervalOfHeight));
//            startRightUp = new Vector2(startLeftBottom.x, startLeftBottom.y + intervalOfHeight);
//        }
//        else if (direction == EPassageDirection.UpLeft)
//        {
//            startLeftBottom = new Vector2(Random.Range(LeftBottom.x, LeftBottom.x + intervalOfWidth), RightTop.y);
//            startRightUp = new Vector2(startLeftBottom.x + intervalOfWidth, startLeftBottom.y);
//        }
//        else if (direction == EPassageDirection.UpRight)
//        {
//            startRightUp = new Vector2(Random.Range(RightTop.x - intervalOfWidth, RightTop.x), RightTop.y);
//            startLeftBottom = new Vector2(startRightUp.x - intervalOfWidth, startRightUp.y);
//        }
//        else if (direction == EPassageDirection.DownLeft)
//        {
//            startLeftBottom = new Vector2(Random.Range(LeftBottom.x, LeftBottom.x + intervalOfWidth), LeftBottom.y);
//            startRightUp = new Vector2(startLeftBottom.x + intervalOfWidth, startLeftBottom.y);
//        }
//        else if (direction == EPassageDirection.DownRight)
//        {
//            startRightUp = new Vector2(Random.Range(RightTop.x - intervalOfWidth, RightTop.x), LeftBottom.y);
//            startLeftBottom = new Vector2(startRightUp.x - intervalOfWidth, startRightUp.y);
//        }
//        else
//        {
//            startLeftBottom = new Vector2();
//            startRightUp = new Vector2();
//            Debug.Log("Gerating Passage Error!");
//        }

//        //  Passage 생성 후 PassageDict에 삽입
//        PassageList.Add(new Passage(startLeftBottom, startRightUp));
//    }

//    private void generateChamber(int minimumPassage, int maximumPassage)
//    {
//        if (minimumPassage < 1 || maximumPassage > (int)EPassageDirection.COUNT)
//        {
//            Debug.Log("The number of passage's direction Error!");
//            return;
//        }
//        int numOfPassage = (int)Random.Range(minimumPassage, maximumPassage + 1.0f);
//        PassageDirectionPool pool = LevelManager.instance.PassageDirectionPool;

//        pool.InitPassageDirectionPool();
        
//        // PassageDirection 방향 생성 후 Dict에 저장
//        for (; numOfPassage > 0; numOfPassage--)
//        {
//            int index = (int)Random.Range(0.0f, numOfPassage);
//            EPassageDirection direction = pool.GetDirection(index);
//            generatePassage(direction);
//        }
//    }

//    // 필수 경로 생성
//    public void StartGeneratingEssentialChamber(int numOfChamber)
//    {
//        generateChamber(ESSENTIAL_MINIMUM_PASSAGE, ESSENTIAL_MINIMUM_PASSAGE);
//        // Chamber의 상대 좌표를 생성하는 알고리즘을 구현해야지 테스트 가능
//        Chamber nextChamber /*= new Chamber()*/ = null;
//        nextChamber.GenerateNextEssentialChamber(numOfChamber - 1, PassageList[0]);
//    }

//    public void GenerateNextEssentialChamber(int restOfChamber, Passage prevPassage)
//    {
//        generateChamber(ESSENTIAL_MINIMUM_PASSAGE, (int)EPassageDirection.COUNT);
//        // 이전 필수 경로와 이번에 생성된 첫번째 경로와 결합
//        prevPassage.CombinePassage(PassageList[0]);
//        PassageList[0] = prevPassage;

//        Chamber nextChamber /*= new Chamber()*/ = null;

//        if (restOfChamber < 2)
//        {
//            nextChamber.GenerateLastEssentialChamber(PassageList[1]);
//        }
//        else
//        {
//            nextChamber.GenerateNextEssentialChamber(restOfChamber - 1, PassageList[1]);
//        }
//    }

//    public void GenerateLastEssentialChamber(Passage prevPassage)
//    {
//        generateChamber(ESSENTIAL_MINIMUM_PASSAGE, ESSENTIAL_MINIMUM_PASSAGE);
//        prevPassage.CombinePassage(PassageList[0]);
//        PassageList[0] = prevPassage;
//    }

//    // 주변 경로 생성
//    public void StartGeneratingFirstAdjacentChamber()
//    {
//        generateChamber(ADJACENT_MINIMUM_PASSAGE, (int)EPassageDirection.COUNT);
//        // Essential Chamber를 하나씩 참조하면서 남는 Passage가 있는 경우 순차적으로 Adjacent Chamber를 생성한다.
//    }
//}
