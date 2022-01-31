namespace GameJam2022.JekyllHyde.Domain.Interface.Room
{
    public interface ILaboratoryRoom : IRoom
    {
        public IGettable RedElement { get; }
        public IInteractable Door { get; }
        public IInteractable Stairs { get; }
        public IInteractable Table { get; }
    }
}