using System.Collections.Generic;
using System.Linq;
using GameJam2022.JekyllHyde.Domain.Interface;

namespace GameJam2022.JekyllHyde.Domain
{
    public abstract class BaseRoom : IRoom
    {
        public IList<IGettable> ItemsToGet { get; private set; }
        public bool HasEnemy { get; private set; }

        private BaseRoom()
        {
            ItemsToGet = new List<IGettable>();
            HasEnemy = false;
        }

        public BaseRoom(IList<IGettable> itemsToGet, bool hasEnemy) : this()
        {
            ItemsToGet = new List<IGettable>(itemsToGet).ToList();
            HasEnemy = hasEnemy;
        }
    }
}