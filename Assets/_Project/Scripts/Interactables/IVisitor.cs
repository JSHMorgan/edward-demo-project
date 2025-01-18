using System;

namespace _Project.Scripts.Interactables
{
    public interface IVisitor
    {
        public void Visit(SpellComponent spellComponent);
    }
}