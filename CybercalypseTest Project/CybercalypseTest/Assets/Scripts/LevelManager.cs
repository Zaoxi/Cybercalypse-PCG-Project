using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : SingleTonManager<LevelManager>
{
    public CGraphDrivenContentsGenerator GraphGenerator { get; private set; }
    public CGridDrivenContentsGenerator GridGenerator { get; private set; }
    public PassageDirectionPool PassageDirectionPool { get; private set; }

    new void Awake()
    {
        base.Awake();

        GraphGenerator = new CGraphDrivenContentsGenerator();
        GridGenerator = new CGridDrivenContentsGenerator();
        PassageDirectionPool = new PassageDirectionPool();
    }
}
