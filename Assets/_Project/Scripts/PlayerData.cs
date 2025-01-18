using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private Sprite sprite = null;
        [SerializeField] private int health = 100;
        [SerializeField] private float speed = 1;
        [SerializeField] private float cooldown = 1.0f;
        
        public float Cooldown => cooldown;
        public float Speed { get => speed; set => speed = value; }
        
        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public void Heal(int heal)
        {
            health = Mathf.Clamp(health + heal, 0, health);
        }

        public void Reset()
        {
            health = health;
        }
        public bool IsDead()
        {
            return health <= 0;
        }

        public Sprite GetSprite()
        {
            return sprite;
        }
    }
}