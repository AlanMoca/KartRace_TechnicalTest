using UnityEngine;
using UnityEngine.EventSystems;

namespace KartRace.Views.MainMenu.Event
{
    public class LobbyPlayButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        Animations.LobbyMenuAnimations lobbyMenuAnimations;

        public void Configure( Animations.LobbyMenuAnimations _lobbyMenuAnimations )
        {
            lobbyMenuAnimations = _lobbyMenuAnimations;
        }

        public void OnPointerEnter( PointerEventData eventData )
        {
            lobbyMenuAnimations.OnPointerEnterPlayButtonAnimation();
        }

        public void OnPointerExit( PointerEventData eventData )
        {
            lobbyMenuAnimations.OnPointerExitPlayButtonAnimation();
        }
    }
}
    
