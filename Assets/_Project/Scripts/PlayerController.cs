using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Interactables;
using _Project.Scripts.Spells;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts
{
    public class PlayerController : MonoBehaviour, IVisitable
    {
        private readonly List<IVisitable> visitableComponents = new();
        [SerializeField] private PlayerData playerData;
        [SerializeField] private PlayerInputReader playerInputReader;
        
        private Vector2 moveInput;
        private SpriteRenderer spriteRenderer;
        private new Rigidbody2D rigidbody2D; // Require new to overwrite depreciated name.
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            playerData.Reset();
            rigidbody2D = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = playerData.GetSprite();
            
            SpellComponent spellComponent = GetComponent<SpellComponent>();
            if (spellComponent != null)
            {
                visitableComponents.Add(spellComponent);
            }
            
            playerInputReader.Move += direction => moveInput = direction;
            playerInputReader.Attack += spellComponent.CastSpell;
            playerInputReader.EnablePlayerActions();
        }
        
        public void Accept(IVisitor visitor)
        {
            foreach (IVisitable component in visitableComponents)
            {
                component.Accept(visitor);
            }
        }

        // Update is called once per frame
        private void Update()
        {
            rigidbody2D.MovePosition(rigidbody2D.position + moveInput * (Time.deltaTime * playerData.Speed));
            if (moveInput != Vector2.zero) {
                float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            HandleDeath();
        }
        

        private void HandleDeath()
        {
            if (!playerData.IsDead()) return;
            Time.timeScale = 0;
            // Add restart popup.
        }
    }
}