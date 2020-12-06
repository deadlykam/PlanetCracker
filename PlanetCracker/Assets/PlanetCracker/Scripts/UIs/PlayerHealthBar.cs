using PlanetCracker.ScriptableObjects.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlanetCracker.UIs
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private IntVariableChange2 _playerHealth;
        [SerializeField] private Image _healthBar;
        [SerializeField] private TextMeshProUGUI _healthText;

        private void OnEnable() => _playerHealth.Subscribe(PlayerHealth);
        private void OnDisable() => _playerHealth.Unsubscribe(PlayerHealth);

        private void Start() 
            => PlayerHealth(_playerHealth.GetValue1(), _playerHealth.GetValue2());

        /// <summary>
        /// This method updates the player health bar and text
        /// </summary>
        /// <param name="currentHealth">The current health of the player, 
        ///                             of type int</param>
        /// <param name="maxHealth">The max health of the player, of type int</param>
        private void PlayerHealth(int currentHealth, int maxHealth)
        {
            _healthBar.fillAmount = ((float)currentHealth) / ((float)maxHealth);
            _healthText.text = $"{currentHealth.ToString()}/{maxHealth.ToString()}";
        }
    }
}