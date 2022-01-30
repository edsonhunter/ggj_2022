using System.Collections.Generic;
using GameJam2022.JekyllHyde.Domain.Interface;

namespace GameJam2022.JekyllHyde.Domain
{
    public class LaboratoryRoom : BaseRoom, ILaboratoryRoom
    {
        public IGettable RedElement { get; }
        public IInteractable Door { get; }
        public IInteractable Stairs { get; }
        public IInteractable Table { get; }

        public LaboratoryRoom(IList<IGettable> itemsToGet, bool hasEnemy) : base(itemsToGet, hasEnemy)
        {
            
        }
    }
}