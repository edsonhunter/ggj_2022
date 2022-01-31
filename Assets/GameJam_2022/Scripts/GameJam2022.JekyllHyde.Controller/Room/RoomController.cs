using GameJam2022.JekyllHyde.Controller.State.Interface;
using GameJam2022.JekyllHyde.Domain.Interface.Room;
using UnityEngine;

namespace GameJam2022.JekyllHyde.Controller.Room
{
    public abstract class RoomController : MonoBehaviour
    {
        protected IStateMachineManager StateMachine { get; set; }
        protected IRoom Room { get; set; }
        public virtual RoomType RoomType { get; protected set; }

        public abstract void Init(IRoom room, IStateMachineManager stateMachine);

        public abstract Vector3 GetStartPositionForEntryPoint(RoomType entryPoint);
    }
}