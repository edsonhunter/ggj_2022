using GameJam2022.JekyllHyde.Controller.Player;
using GameJam2022.JekyllHyde.Controller.State.Interface;

namespace GameJam2022.JekyllHyde.Controller.State
{
    public class TutorialState : IState
    {
        private IStateMachineManager StateMachineManager { get; set; }
        public IStateMachineContext Context { get; private set; }
        
        public TutorialState(IStateMachineContext context)
        {
            Context = context;
        }
        
        public void Initialize(IStateMachineManager stateMachineManager)
        {
            StateMachineManager = stateMachineManager;
            
            Context.KeyboardController.ToggleKeyboard(false);
            Context.KeyboardController.OnTutorialEnd += StopTutorial;
            
            StartTutorial();
        }

        private void StartTutorial()
        {
            Context.KeyboardController.StartTutorial();
            Context.PlayerController.ShowTutorial(true);
        }

        private void StopTutorial()
        {
            Context.PlayerController.ShowTutorial(false);
            StateMachineManager.SwapState(new LaboratoryState(Context));
            Context.KeyboardController.OnTutorialEnd -= StopTutorial;
        }
    }
}