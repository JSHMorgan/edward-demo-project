using UnityEngine;

namespace _Project.Scripts.Spells
{
    [CreateAssetMenu(fileName = "Fireball", menuName = "Scriptable Objects/Fireball")]
    public class FireballSpellStrategy : SpellStrategy
    {
        public GameObject fireballPrefab;
        public float speed = 10.0f;

        public override void CastSpell(Transform origin)
        {
            Vector3 spawnPos = origin.position;
            GameObject fireball = Instantiate(fireballPrefab, spawnPos, Quaternion.identity);
            fireball.GetComponent<Rigidbody2D>().linearVelocity = origin.right * speed;
            Debug.Log(fireball.GetComponent<Rigidbody2D>().linearVelocity);
        }
    }
}