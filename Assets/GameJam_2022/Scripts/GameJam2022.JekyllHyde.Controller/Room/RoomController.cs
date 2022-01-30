using System.Collections.Generic;
using GameJam2022.JekyllHyde.Controller.Room.Interface;
using GameJam2022.JekyllHyde.Controller.State.Interface;
using GameJam2022.JekyllHyde.Domain.Interface;
using UnityEngine;

namespace GameJam2022.JekyllHyde.Controller.Room
{
    public abstract class RoomController : MonoBehaviour
    {
        public IStateMachineManager StateMachine { get; private set; }
        public IRoom Room { get; protected set; }
        public RoomType RoomType { get; set; }

        public virtual void Init(IRoom room, IStateMachineManager stateMachine)
        {
            Room = room;
            StateMachine = stateMachine;
        }
    }
}