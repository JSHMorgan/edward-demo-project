using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.Interactables
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private SpellPowerUp spellPowerUp;

        private void OnTriggerEnter2D(Collider2D other)
        {
            IVisitable visitable = other.GetComponent<IVisitable>();
            visitable?.Accept(spellPowerUp);
            Destroy(gameObject);
        }
    }
}