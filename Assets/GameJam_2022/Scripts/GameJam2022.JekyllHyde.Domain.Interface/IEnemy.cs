namespace GameJam2022.JekyllHyde.Domain.Interface
{
    public interface IEnemy
    {
        PlayerOrientation Orientation { get; }
        float CurrentDirection { get; set; }
        bool Chasing { get; }

        bool ChangeDirection(float direction);
        bool ChaseUpdate(bool playerHidden, float distance, float playerX, float enemyX);
    }
}