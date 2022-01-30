namespace GameJam2022.JekyllHyde.Controller.State.Interface
{
    public interface IState
    {
        IStateMachineContext Context { get; }
        
        void Initialize(IStateMachineManager stateMachineManager);
    }
}