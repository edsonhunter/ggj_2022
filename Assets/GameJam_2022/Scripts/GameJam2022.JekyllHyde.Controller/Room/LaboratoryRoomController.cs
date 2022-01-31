using System.Collections.Generic;
using GameJam2022.JekyllHyde.Controller.Room.Interface;
using GameJam2022.JekyllHyde.Controller.State;
using GameJam2022.JekyllHyde.Controller.State.Interface;
using GameJam2022.JekyllHyde.Domain.Interface;
using GameJam2022.JekyllHyde.Domain.Interface.Room;
using UnityEngine;

namespace GameJam2022.JekyllHyde.Controller.Room
{
    public class LaboratoryRoomController : RoomController
    {
        [field: SerializeField] private InteractiveController Door { get; set; }
        [field: SerializeField] private InteractiveController Stairs { get; set; }
        [field: SerializeField] private InteractiveController Table { get; set; }

        public override RoomType RoomType => RoomType.Laboratorio;
        private ILaboratoryRoom LaboratoryRoom => Room as ILaboratoryRoom;

        public override void Init(IRoom room, IStateMachineManager stateMachine)
        {
            Room = room;
            StateMachine = stateMachine;
            InitializeRoomElements();
        }

        public override Vector3 GetStartPositionForEntryPoint(RoomType entryPoint)
        {
            switch (entryPoint)
            {
                case RoomType.Corredor:
                    return Stairs.transform.position;        
            }
            return Vector3.one;
        }

        private void InitializeRoomElements()
        {
            Table.Init(LaboratoryRoom.Table, () =>
            {
                Debug.Log("Player Hide");
            });
            Stairs.Init(LaboratoryRoom.Door, () =>
            {
                StateMachine.SwapState(new CorridorState(StateMachine.CurrentState.Context));
            });
        }
    }
}