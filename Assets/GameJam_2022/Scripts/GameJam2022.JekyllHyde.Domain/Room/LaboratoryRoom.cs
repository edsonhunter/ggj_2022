using System.Collections.Generic;
using GameJam2022.JekyllHyde.Domain.Interface;
using GameJam2022.JekyllHyde.Domain.Interface.Room;

namespace GameJam2022.JekyllHyde.Domain.Room
{
    public class LaboratoryRoom : BaseRoom, ILaboratoryRoom
    {
        public IGettable RedElement { get; }
        public IInteractable Door { get; }
        public IInteractable Stairs { get; }
        public IInteractable Table { get; }

        public override RoomType RoomType => RoomType.Laboratorio;

        public LaboratoryRoom(IGettable redElement, IInteractable door, IInteractable stairs, IInteractable table)
        {
            RedElement = redElement;
            Door = door;
            Stairs = stairs;
            Table = table;
        }
    }
}