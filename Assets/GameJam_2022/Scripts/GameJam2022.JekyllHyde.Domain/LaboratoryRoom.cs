using System.Collections.Generic;
using GameJam2022.JekyllHyde.Domain.Interface;

namespace GameJam2022.JekyllHyde.Domain
{
    public class LaboratoryRoom : BaseRoom, ILaboratoryRoom
    {
        public IGettable RedElement { get; }
        
        public LaboratoryRoom(IList<IGettable> itemsToGet, bool hasEnemy) : base(itemsToGet, hasEnemy)
        {
        }
    }
}