namespace EducationPathways.ServiceBus.Handling
{
    public interface IEventHandlerRegistry
    {
        void Register(IEventHandler handler);
    }
}
