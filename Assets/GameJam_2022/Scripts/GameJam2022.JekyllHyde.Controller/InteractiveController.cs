using GameJam2022.JekyllHyde.Domain.Interface;
using System;
using UnityEngine;

namespace GameJam2022.JekyllHyde.Controller
{
    public class InteractiveController : MonoBehaviour
    {
        private IInteractable Interactable { get; set; }
        private Action OnInteract { get; set; }

        public void Init(IInteractable interactable, Action onInteract)
        {
            Interactable = interactable;
            OnInteract = onInteract ?? throw new InvalidOperationException("Impossivel acao do objeto ser inexistente");
        }

        public void Interact(IPlayer player)
        {
            if (Interactable.Interact(player))
            {
                OnInteract();
                if (Interactable is IGettable) Destroy(gameObject);
            }
        }
    }
}
