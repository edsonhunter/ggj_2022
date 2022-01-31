using System;
using GameJam2022.JekyllHyde.Controller.State;
using GameJam2022.JekyllHyde.Controller.State.Interface;
using GameJam2022.JekyllHyde.Domain.Interface.Room;
using UnityEngine;

namespace GameJam2022.JekyllHyde.Controller.Room
{
    public class CorridorRoomController : RoomController
    {
        [field: SerializeField] private InteractiveController GardenDoor { get; set; }
        [field: SerializeField] private InteractiveController AtticStairs { get; set; }
        [field: SerializeField] private InteractiveController Table { get; set; }
        [field: SerializeField] private InteractiveController LaboratoryDoor { get; set; }
        [field: SerializeField] private InteractiveController BedroomDoor { get; set; }
        
        private ICorridorRoom CorridorRoom => Room as ICorridorRoom;
        public override RoomType RoomType => RoomType.Corredor;

        public override void Init(IRoom room, IStateMachineManager stateMachine)
        {
            Room = room as ICorridorRoom;
            StateMachine = stateMachine;
            InitializeRoomElements();
        }

        public override Vector3 GetStartPositionForEntryPoint(RoomType entryPoint)
        {
            switch (entryPoint)
            {
                case RoomType.Laboratorio:
                    return LaboratoryDoor.transform.position;
                case RoomType.Quarto:
                    return BedroomDoor.transform.position;
                case RoomType.Sotao:
                    return AtticStairs.transform.position;
                case RoomType.Quintal:
                    return GardenDoor.transform.position;
            }
            return Vector3.one;
        }
        
        private void InitializeRoomElements()
        {
            LaboratoryDoor.Init(CorridorRoom.LaboratoryDoor, () =>
            {
                StateMachine.SwapState(new LaboratoryState(StateMachine.CurrentState.Context));
            });
        }
    }
}