using GameJam2022.JekyllHyde.Controller.State.Interface;

namespace GameJam2022.JekyllHyde.Controller.State
{
    public class LaboratoryState : IState
    {
        private IStateMachineManager Manager { get; set; }
        public IStateMachineContext Context { get; }
        
        public LaboratoryState(IStateMachineContext context)
        {
            Context = context;
        }

        public void Initialize(IStateMachineManager stateMachineManager)
        {
            Manager = stateMachineManager;
            Context.KeyboardController.ToggleKeyboard(true);
        }
    }
}