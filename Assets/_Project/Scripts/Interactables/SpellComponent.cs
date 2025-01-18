using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Spells;
using UnityEngine;

namespace _Project.Scripts.Interactables
{
    public class SpellComponent : MonoBehaviour, IVisitable
    {
        public SpellStrategy spell;
        private bool isOnCooldown = false;
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            Debug.Log("SpellComponent.Accept");
        }
        
        public void CastSpell()
        {
            if (isOnCooldown) return;
            spell.CastSpell(transform);
            Debug.Log("Pew pew! (Spell Cast)");
            StartCoroutine(HandleCooldown());
        }

        private IEnumerator HandleCooldown()
        {
            isOnCooldown = true;
            yield return new WaitForSeconds(spell.Cooldown);
            isOnCooldown = false;
        }
    }
}