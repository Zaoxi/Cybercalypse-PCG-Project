using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class PassageDirectionPool
{
    private List<EPassageDirection> passageDirectionPool;

    public PassageDirectionPool()
    {
        passageDirectionPool = new List<EPassageDirection>();
    }

    public void InitPassageDirectionPool()
    {
        passageDirectionPool.Clear();
        // PassagePool 생성
        for (int i = 0; i < (int)EPassageDirection.COUNT; i++)
        {
            passageDirectionPool.Add((EPassageDirection)i);
        }
    }

    public EPassageDirection GetDirection(int index)
    {
        if(index >= passageDirectionPool.Count)
        {
            Debug.Log("Passage Direction Pool Getting Error!");
        }

        EPassageDirection direction = passageDirectionPool[index];
        passageDirectionPool.RemoveAt(index);
        return direction;
    }
}

