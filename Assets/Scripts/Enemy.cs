using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Enemy", menuName="Enemy/Create New Enemy")]
public class Enemy : ScriptableObject
{
    public int id;
    public string enemyName;
    public float health;
}
