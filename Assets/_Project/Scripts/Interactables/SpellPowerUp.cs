using _Project.Scripts.Spells;
using UnityEngine;

namespace _Project.Scripts.Interactables
{
    [CreateAssetMenu(fileName = "Spell", menuName = "Scriptable Objects/SpellPowerUp")]
    public class SpellPowerUp : ScriptableObject, IVisitor
    {
        [SerializeField] private SpellStrategy spell;
        public void Visit(SpellComponent spellComponent)
        {
            spellComponent.spell = spell;
        }
    }
}