namespace GameJam2022.JekyllHyde.Controller.State.Interface
{
    public interface IStateMachineManager
    {
        void PushState(IState newState);
        void PopState();
        void SwapState(IState newState);
    }
}