using GameJam2022.JekyllHyde.Domain.Interface;

namespace GameJam2022.JekyllHyde.Domain
{
    public class Enemy : IEnemy
    {
        public PlayerOrientation Orientation { get; private set; }
        public float CurrentDirection { get; set; }
        public bool Chasing { get; private set; }
        private float ChaseDistance = 6f;

        public Enemy(PlayerOrientation orientation)
        {
            Orientation = orientation;
            CurrentDirection = (orientation == PlayerOrientation.Right) ? 1 : -1;
            Chasing = false;
        }
        
        public bool ChangeDirection(float direction)
        {
            if (CurrentDirection < 0 && direction > 0)
            {
                CurrentDirection = direction;
                Orientation = PlayerOrientation.Right;
                return true;
            }

            if (CurrentDirection > 0 && direction < 0)
            {
                CurrentDirection = direction;
                Orientation = PlayerOrientation.Left;
                return true;
            }

            CurrentDirection = direction;
            
            return false;
        }

        public bool ChaseUpdate(bool playerHidden,  float distance, float playerX, float enemyX)
        {
            if (!Chasing && playerHidden)
                return false;

            if (Chasing && playerHidden)
            {
                Chasing = false;
                return true;
            }

            if (CurrentDirection < 0 && playerX > enemyX)
                return false;

            if (CurrentDirection > 0 && playerX < enemyX)
                return false;

            if (distance < ChaseDistance && !Chasing)
            {
                Chasing = true;
                return true;
            }
            else if (distance > ChaseDistance && Chasing)
            {
                Chasing = false;
                return true;
            }

            return false;
        }
    }
}