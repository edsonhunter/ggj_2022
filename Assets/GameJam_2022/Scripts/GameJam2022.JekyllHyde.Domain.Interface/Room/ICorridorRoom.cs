namespace GameJam2022.JekyllHyde.Domain.Interface.Room
{
    public interface ICorridorRoom : IRoom
    {
        IInteractable GardenDoor { get; }
        IInteractable AtticStairs { get; }
        IInteractable Table { get; }
        IInteractable LaboratoryDoor { get; }
        IInteractable BedroomDoor { get; }
    }
}