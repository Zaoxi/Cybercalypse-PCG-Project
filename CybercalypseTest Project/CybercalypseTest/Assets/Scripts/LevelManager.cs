using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : SingleTonManager<LevelManager>
{
    public CDungeonDrivenContentsGenerator DungeonGenerator { get; private set; }
    public CPlayerDrivenContentsGenerator WorldGenerator { get; private set; }
    public PassageDirectionPool PassageDirectionPool { get; private set; }

	new void Awake()
    {
        base.Awake();

        DungeonGenerator = new CDungeonDrivenContentsGenerator();
        WorldGenerator = new CPlayerDrivenContentsGenerator();
        PassageDirectionPool = new PassageDirectionPool();
    }

    public void StartDungeonGenerator()
    {
        DungeonGenerator.StartDungeonGenerator();
    }
}
