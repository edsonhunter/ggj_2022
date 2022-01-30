using GameJam2022.JekyllHyde.Controller.Player;
using GameJam2022.JekyllHyde.Controller.Room;
using GameJam2022.JekyllHyde.Controller.Room.Interface;

namespace GameJam2022.JekyllHyde.Controller.State.Interface
{
    public interface IStateMachineContext
    {
        public KeyboardController KeyboardController { get; }
        public PlayerController PlayerController { get; }
        public IRoomManager RoomManager { get; }
        public TransitionController TransitionController { get; }
    }
}