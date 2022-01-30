using GameJam2022.JekyllHyde.Controller.State.Interface;

namespace GameJam2022.JekyllHyde.Controller.State
{
    public class LaboratoryState : IState
    {
        private IStateMachineManager Manager { get; set; }
        private KeyboardController KeyboardController { get; set; }
        
        public LaboratoryState(KeyboardController keyboardController)
        {
            KeyboardController = keyboardController;
        }

        public void Initialize(IStateMachineManager stateMachineManager)
        {
            Manager = stateMachineManager;
            KeyboardController.ToggleKeyboard(true);
        }
    }
}