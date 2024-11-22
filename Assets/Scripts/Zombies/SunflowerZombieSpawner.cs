using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerZombieSpawner : Spawner
{
    public override IZombie CreateZombie()
    {
        return new SunflowerZombie();
    }
}
