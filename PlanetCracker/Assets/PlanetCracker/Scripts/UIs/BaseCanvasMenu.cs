using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetCracker.UIs
{
    public abstract class BaseCanvasMenu : MonoBehaviour
    {
        [SerializeField] private Canvas[] _canvases; // All canvases for this menu
        private int _indexCanvas; // Index for loop through all the canvases

        /// <summary>
        /// This method sets the enable of the canvases.
        /// </summary>
        /// <param name="isEnabled">The flag to use to set the enable of canvases,
        ///                         of type bool</param>
        private void SetCanvases(bool isEnabled)
        {
            // Loop for setting the canvases enables
            for (_indexCanvas = 0; _indexCanvas < _canvases.Length; _indexCanvas++)
                _canvases[_indexCanvas].enabled = isEnabled;
        }

        /// <summary>
        /// This method checks if the menu is being shown.
        /// </summary>
        /// <returns>True means shown, false otherwise, of type bool</returns>
        public bool IsShown() => _canvases[0].enabled;

        /// <summary>
        /// This method shows the menu.
        /// </summary>
        public virtual void ShowMenu() => SetCanvases(true);

        /// <summary>
        /// This method hides the menu.
        /// </summary>
        public virtual void HideMenu() => SetCanvases(false);
    }
}