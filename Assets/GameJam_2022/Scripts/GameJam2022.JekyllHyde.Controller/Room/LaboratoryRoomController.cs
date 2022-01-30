using GameJam2022.JekyllHyde.Domain.Interface;
using UnityEngine;

namespace GameJam2022.JekyllHyde.Controller.Room
{
    public class LaboratoryRoomController : MonoBehaviour
    {
        private ILaboratoryRoom LaboratoryRoom { get; set; }

        public void Init(ILaboratoryRoom laboratoryRoom)
        {
            LaboratoryRoom = laboratoryRoom;
        }
    }
}