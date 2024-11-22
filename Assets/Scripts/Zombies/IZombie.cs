using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IZombie
{
    void Spawn(Vector3 position);
    void Attack();
    void Die();
}
