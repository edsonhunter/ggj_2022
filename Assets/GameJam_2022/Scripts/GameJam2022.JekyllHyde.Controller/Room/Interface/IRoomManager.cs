using GameJam2022.JekyllHyde.Domain.Interface;
using GameJam2022.JekyllHyde.Domain.Interface.Room;

namespace GameJam2022.JekyllHyde.Controller.Room.Interface
{
    public interface IRoomManager
    {
        public RoomController CurrentRoom { get; }
        void LoadRoom(RoomType corredor);
    }
}