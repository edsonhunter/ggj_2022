using System.Collections.Generic;

namespace GameJam2022.JekyllHyde.Domain.Interface
{
    public interface IRoom
    {
        RoomType RoomType { get; }
    }
    
    public enum RoomType
    {
        Unknown,
        Laboratorio,
        Corredor,
        Quarto,
        Sotao,
        Quintal,
    }
}