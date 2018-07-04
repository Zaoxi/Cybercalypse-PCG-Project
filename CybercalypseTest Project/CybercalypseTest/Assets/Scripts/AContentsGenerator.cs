using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 맵 구성요소 생성기를 구현하기 위한 추상 클래스
/// </summary>
public abstract class AContentsGenerator : MonoBehaviour {
    // Tile을 생성하기 위한 최소 정보
    public CContent[] contents;
    public int chamberWidth, chamberHeight;
    // 각 ETileType별로 어떠한 요소가 있는지 저장하는 Dictionary
    protected Dictionary<ETileType, List<CContent>> elementDict;


    protected virtual void Awake()
    {
        initializeDict();
        sortContentsIntoDictionary();
    }

    /// <summary>
    /// elementDict를 현재 존재하는 ETileType에 따라서 List를 저장
    /// </summary>
    private void initializeDict()
    {
        elementDict = new Dictionary<ETileType, List<CContent>>();

        for (ETileType t = ETileType.Flat; t<ETileType.COUNT; t++)
        {
            elementDict.Add(t, new List<CContent>());
        }
    }

    /// <summary>
    /// Contents를 Dictionary로 분류하는 메소드
    /// </summary>
    private void sortContentsIntoDictionary()
    {
        if(contents == null)
        {
            Debug.Log("The Contents is Null!");
        }

        for (int i=0; i<contents.Length; i++)
        {
            elementDict[contents[i].tileType].Add(contents[i]);
        }
    }
    /// <summary>
    /// 실제 맵 생성을 요청하는 메소드
    /// </summary>
    public abstract void GenerateContents();
}
