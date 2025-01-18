using UnityEngine;

namespace _Project.Scripts.Spells
{
    public abstract class SpellStrategy : ScriptableObject
    {
        [SerializeField] private float cooldown;
        
        public float Cooldown => cooldown;
        public abstract void CastSpell(Transform origin);
    }
}