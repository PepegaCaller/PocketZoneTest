
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerShooting _playerShooting;
    public void Initialize()
    {
        _playerHealth.Initialize();
        _playerController.Initialize();
    }

    public void UpdatePlayerSystem()
    {
        _playerController.UpdateCharacterController();
    }
}
