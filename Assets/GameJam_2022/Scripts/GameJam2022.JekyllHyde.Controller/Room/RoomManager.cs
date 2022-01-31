using System;
using System.Collections.Generic;
using System.Linq;
using GameJam2022.JekyllHyde.Controller.Room.Interface;
using GameJam2022.JekyllHyde.Controller.State.Interface;
using GameJam2022.JekyllHyde.Domain.Interface;
using GameJam2022.JekyllHyde.Domain.Interface.Room;

namespace GameJam2022.JekyllHyde.Controller.Room
{
    public class RoomManager : IRoomManager
    {
        private IList<RoomController> RoomControllers { get; set; }
        
        public RoomController CurrentRoom { get; private set; }
        private IStateMachineManager StateMachineManager { get; set; } 

        public RoomManager(IList<RoomController> roomControllers, IStateMachineManager stateMachineManager, IList<IRoom> rooms)
        {
            RoomControllers = new List<RoomController>(roomControllers);
            StateMachineManager = stateMachineManager;
            InitializeRooms(rooms);
        }

        private void InitializeRooms(IList<IRoom> rooms)
        {
            foreach (var roomController in RoomControllers)
            {
                var roomDomain = rooms.FirstOrDefault(room => roomController.RoomType == room.RoomType);
                roomController.Init(roomDomain, StateMachineManager);
            }
        }
        
        private RoomController GetRoom(RoomType roomType)
        {
            var roomController = RoomControllers.FirstOrDefault(x => x.RoomType == roomType);
            if (roomController == null)
            {
                throw new InvalidOperationException("Room inexistente");
            }

            return roomController;
        }

        public void LoadRoom(RoomType room)
        {
            if (CurrentRoom != null)
            {
                CurrentRoom.gameObject.SetActive(false);    
            }

            CurrentRoom = GetRoom(room);
            CurrentRoom.gameObject.SetActive(true);
        }
    }
}