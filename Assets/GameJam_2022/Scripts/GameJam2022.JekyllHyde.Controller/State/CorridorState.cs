using GameJam2022.JekyllHyde.Controller.State.Interface;
using GameJam2022.JekyllHyde.Domain.Interface;

namespace GameJam2022.JekyllHyde.Controller.State
{
    public class CorridorState : IState
    {
        private IStateMachineManager Manager { get; set; }
        public IStateMachineContext Context { get; }

        public CorridorState(IStateMachineContext context)
        {
            Context = context;
        }

        public void Initialize(IStateMachineManager stateMachineManager)
        {
            Manager = stateMachineManager;
            Context.KeyboardController.ToggleKeyboard(true);
            Context.RoomManager.LoadRoom(RoomType.Corredor);
            Context.PlayerController.SetNewRoom(Context.RoomManager.CurrentRoom, RoomType.Laboratorio);
        }
    }
}