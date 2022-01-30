namespace GameJam2022.JekyllHyde.Controller.State.Interface
{
    public interface IStateMachineManager
    {
        IState CurrentState { get; }
        void PushState(IState newState);
        void PopState();
        void SwapState(IState newState);
    }
}