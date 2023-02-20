using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyData")]
public class EnemyDatas : ScriptableObject
{
    public string enemyName;
    public int maxHP;
    public int bulletDamage;
    public int knifeDamage;
    public float speed;
    public int attack;
}