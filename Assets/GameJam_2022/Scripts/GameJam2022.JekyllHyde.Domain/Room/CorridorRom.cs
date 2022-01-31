using GameJam2022.JekyllHyde.Domain.Interface;
using GameJam2022.JekyllHyde.Domain.Interface.Room;

namespace GameJam2022.JekyllHyde.Domain.Room
{
    public class CorridorRom : ICorridorRoom
    {
        public RoomType RoomType => RoomType.Corredor;
        public IInteractable GardenDoor { get; }
        public IInteractable AtticStairs { get; }
        public IInteractable Table { get; }
        public IInteractable LaboratoryDoor { get; }
        public IInteractable BedroomDoor { get; }
        
        public CorridorRom(IInteractable gardenDoor, IInteractable atticStairs, IInteractable table, IInteractable laboratoryDoor, IInteractable bedroomDoor)
        {
            GardenDoor = gardenDoor;
            AtticStairs = atticStairs;
            Table = table;
            LaboratoryDoor = laboratoryDoor;
            BedroomDoor = bedroomDoor;
        }
    }
}