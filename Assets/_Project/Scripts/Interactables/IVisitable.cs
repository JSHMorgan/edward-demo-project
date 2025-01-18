namespace _Project.Scripts.Interactables
{
    public interface IVisitable
    {
        public void Accept(IVisitor gameObject);
    }
}