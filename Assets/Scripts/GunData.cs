using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "Scriptable Object/GunData")]
public class GunData : ScriptableObject
{
    public float fireRate = 1f;

    public float damage = 10f;

    public GameObject shootParticlesPrefab;

    public string shootSoundName = "Shoot";
}