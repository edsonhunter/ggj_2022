using System.Collections.Generic;
using GameJam2022.JekyllHyde.Controller.Room.Interface;
using GameJam2022.JekyllHyde.Controller.State;
using GameJam2022.JekyllHyde.Controller.State.Interface;
using GameJam2022.JekyllHyde.Domain.Interface;
using UnityEngine;

namespace GameJam2022.JekyllHyde.Controller.Room
{
    public class LaboratoryRoomController : RoomController
    {
        [field: SerializeField] private InteractiveController Door { get; set; }
        [field: SerializeField] private InteractiveController Stairs { get; set; }
        [field: SerializeField] private InteractiveController Table { get; set; }

        public override RoomType RoomType => RoomType.Laboratorio;
        private ILaboratoryRoom LaboratoryRoom { get; set; }

        public override void Init(IRoom room, IStateMachineManager stateMachine)
        {
            LaboratoryRoom = room as ILaboratoryRoom;
            base.Init(LaboratoryRoom, stateMachine);
            InitializeRoomElements();
        }

        public override Vector3 GetStartPositionForEntryPoint(RoomType entryPoint)
        {
            return Door.transform.position;
        }

        private void InitializeRoomElements()
        {
            Door.Init(LaboratoryRoom.Door, () =>
            {
                StateMachine.SwapState(new CorridorState(StateMachine.CurrentState.Context));
            });
        }
    }
}