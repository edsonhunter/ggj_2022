namespace GameJam2022.JekyllHyde.Domain.Interface
{
    public interface ILaboratoryRoom : IRoom
    {
        IGettable RedElement { get; }
    }
}