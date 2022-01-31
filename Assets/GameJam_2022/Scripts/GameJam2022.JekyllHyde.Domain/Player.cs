using GameJam2022.JekyllHyde.Domain.Interface;
using System;
using UnityEngine;

namespace GameJam2022.JekyllHyde.Domain
{
    public class Player : IPlayer
    {
        public bool[] Items { get; private set; }
        public bool IsHidden { get; private set; }
        public bool CanHide { get; set; }
        public bool Tutorial { get; set; }
        public PlayerOrientation Orientation { get; private set; }
        private float CurrentDirection { get; set; }

        public Player(PlayerOrientation orientation)
        {
            Orientation = orientation;
            CurrentDirection = 1;
            Items = new bool[5];
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

        public bool Hide(bool hide)
        {
            Debug.Log($"Player Hide: current {IsHidden} | new {hide} - can hide: {CanHide}");
            if (hide == IsHidden) return false;

            if (!IsHidden && CanHide) IsHidden = true;
            else IsHidden = false;

            return true;
        }

        public bool PickupItem(int itemId)
        {
            try
            {
                Items[itemId] = true;
                Debug.Log($"item picked: {itemId}");
                Debug.Log($"inventory updated ({string.Join(",", Items)})");
                return true;
            }
            catch (IndexOutOfRangeException e)
            {
                Debug.LogException(e);
                return false;
            }
        }

        public void ShowTutorial(bool show)
        {
            if (Tutorial == show)
            {
                throw new InvalidOperationException("Impossível inicializar tutorial já inicializado!");
            }

            Tutorial = show;
        }
    }
}