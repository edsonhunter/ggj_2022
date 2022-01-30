namespace GameJam2022.JekyllHyde.Domain.Interface
{
    public interface IPlayer
    {
        bool[] Items { get; }
        bool IsHidden { get; }
        bool CanHide { get; set; }
        bool Tutorial { get; set; } 
        PlayerOrientation Orientation { get; }

        bool ChangeDirection(float direction);
        bool Hide(bool hide);
        bool PickupItem(int itemId);
        void ShowTutorial(bool show);
    }

    public enum PlayerOrientation
    {
        Unknown = 0,
        Right = 1,
        Left = -1,
    }
}