using GameJam2022.JekyllHyde.Domain.Interface;

namespace GameJam2022.JekyllHyde.Controller.Room.Interface
{
    public interface IRoomManager
    {
        public RoomController CurrentRoom { get; }
        void LoadRoom(RoomType corredor);
    }
}