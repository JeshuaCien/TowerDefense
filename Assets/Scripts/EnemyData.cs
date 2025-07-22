using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Object/EnemyData")]
public class EnemyData : ScriptableObject
{
    public float _RunSpped = 5f;

    public float _AttackDamage = 10f;

    public float _AttackRange = 2f;

    public float _AttackDuration = 1f;

    public float _AttackWaitTime = 0.5f;

    public string _RunAnimationName = "Run";

    public string _AttackAnimationName = "Attack";

    public string _DeathAnimationName = "Death";

    public string _HitAnimationName = "Hit";

    public string _WinAnimationName = "Win";
}
