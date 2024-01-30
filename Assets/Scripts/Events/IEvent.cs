namespace Events
{
    public interface IEvent
    {
        public bool IsActivable();
        public void Activate();
    }
}
