using System.Collections.Generic;
using GameJam2022.JekyllHyde.Domain;
using GameJam2022.JekyllHyde.Domain.Interface;
using GameJam2022.JekyllHyde.Domain.Interface.Room;
using GameJam2022.JekyllHyde.Domain.Room;

namespace GameJam2022.JekyllHyde.Util
{
    public static class Factory
    {
        public static IPlayer CreatePlayer(PlayerOrientation playerOrientation)
        {
            return new Player(playerOrientation);
        }

        public static IEnemy CreateEnemy(PlayerOrientation enemyOrientation)
        {
            return new Enemy(enemyOrientation);
        }

        public static IGettable CreateGettableItem(int itemId)
        {
            return new GettableItem(itemId);
        }

        public static ILaboratoryRoom CreateLaboratory()
        {
            return new LaboratoryRoom(CreateGettableItem(0), new InteractableItem(), new InteractableItem(), new InteractableItem());
        }

        public static ICorridorRoom CreateCorridor()
        {
            return new CorridorRom(new InteractableItem(), new InteractableItem(), new InteractableItem(), new InteractableItem(), new InteractableItem());
        }
    }
}