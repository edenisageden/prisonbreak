using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKillable
{
    void Kill();
}

public interface IEquiptable
{
    void Equipt(GameObject player);
}

public interface IDamagable
{
    void Damage(int damage);
}

