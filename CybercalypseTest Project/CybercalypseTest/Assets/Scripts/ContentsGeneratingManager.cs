using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentsGeneratingManager : SingleTonManager<ContentsGeneratingManager>
{
    public CDungeonDrivenContentsGenerator DungeonGenerator { get; private set; }
    public CPlayerDrivenContentsGenerator WorldGenerator { get; private set; }

	new void Awake()
    {
        base.Awake();

        DungeonGenerator = new CDungeonDrivenContentsGenerator();
        WorldGenerator = new CPlayerDrivenContentsGenerator();
    }


}
