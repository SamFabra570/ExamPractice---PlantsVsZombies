using UnityEngine;

public abstract class Spawner
{
    // Factory Method
    public abstract IZombie CreateZombie();
    
    // Common method to spawn enemy
    public void SpawnEnemy(Vector3 position)
    {
        IZombie zombie = CreateZombie();
        zombie.Spawn(position);
        Debug.Log("Enemy has been spawned.");
    }
}