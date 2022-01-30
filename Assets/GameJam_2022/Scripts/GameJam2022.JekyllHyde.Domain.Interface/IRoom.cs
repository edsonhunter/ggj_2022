using System.Collections.Generic;

namespace GameJam2022.JekyllHyde.Domain.Interface
{
    public interface IRoom
    {
        IList<IGettable> ItemsToGet { get; }
        bool HasEnemy { get; }
    }
}