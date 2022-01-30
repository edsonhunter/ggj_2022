using GameJam2022.JekyllHyde.Controller.Player;
using GameJam2022.JekyllHyde.Controller.Room;
using GameJam2022.JekyllHyde.Controller.Room.Interface;
using GameJam2022.JekyllHyde.Controller.State.Interface;

namespace GameJam2022.JekyllHyde.Controller.State
{
    public class StateMachineContext : IStateMachineContext
    {
        public KeyboardController KeyboardController { get; private set; }
        public PlayerController PlayerController { get; private set; }
        public IRoomManager RoomManager { get; private set; }
        public TransitionController TransitionController { get; private set; }
        
        public StateMachineContext(KeyboardController keyboardController, PlayerController playerController, IRoomManager roomManager, TransitionController transitionController)
        {
            KeyboardController = keyboardController;
            PlayerController = playerController;
            RoomManager = roomManager;
            TransitionController = transitionController;
        }
    }
}