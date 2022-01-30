using GameJam2022.JekyllHyde.Controller.Player;
using GameJam2022.JekyllHyde.Controller.State.Interface;

namespace GameJam2022.JekyllHyde.Controller.State
{
    public class TutorialState : IState
    {
        private IStateMachineManager StateMachineManager { get; set; }
        private KeyboardController KeyboardController { get; set; }
        private PlayerController PlayerController { get; set; }

        public TutorialState(KeyboardController keyboardController, PlayerController playerController)
        {
            KeyboardController = keyboardController;
            PlayerController = playerController;
        }
        
        public void Initialize(IStateMachineManager stateMachineManager)
        {
            StateMachineManager = stateMachineManager;
            
            KeyboardController.ToggleKeyboard(false);
            KeyboardController.OnTutorialEnd += StopTutorial;
            
            StartTutorial();
        }

        private void StartTutorial()
        {
            KeyboardController.StartTutorial();
            PlayerController.ShowTutorial(true);
        }

        private void StopTutorial()
        {
            PlayerController.ShowTutorial(false);
            StateMachineManager.SwapState(new LaboratoryState(KeyboardController));
            KeyboardController.OnTutorialEnd -= StopTutorial;
        }
    }
}