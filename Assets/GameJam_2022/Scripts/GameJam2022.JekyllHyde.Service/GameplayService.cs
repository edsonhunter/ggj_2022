using System.Collections.Generic;
using GameJam2022.JekyllHyde.Domain.Interface;
using GameJam2022.JekyllHyde.Service.Interface;
using GameJam2022.JekyllHyde.Util;

namespace GameJam2022.JekyllHyde.Service
{
    public class GameplayService : IGameplayService
    {
        public IPlayer Player { get; private set; }
        public IList<IRoom> Rooms { get; private set; }

        public GameplayService()
        {
            Rooms = new List<IRoom>();
            Player = Factory.CreatePlayer(PlayerOrientation.Right);
        }
        
        public IList<IRoom> CreateRooms()
        {
            //Laboratorio
            var lab = Factory.CreateLaboratory();
            Rooms.Add(lab);
            return Rooms;
        }
    }
}