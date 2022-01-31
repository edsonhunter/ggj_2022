using System.Collections.Generic;
using System.Linq;
using GameJam2022.JekyllHyde.Domain.Interface;
using GameJam2022.JekyllHyde.Domain.Interface.Room;

namespace GameJam2022.JekyllHyde.Domain
{
    public abstract class BaseRoom : IRoom
    {
        public virtual RoomType RoomType { get; protected set; }
        public bool HasEnemy { get; private set; }

        public BaseRoom()
        {
            HasEnemy = false;
        }
    }
}