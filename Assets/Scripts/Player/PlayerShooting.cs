using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private Item _ammo;


    public void Fire()
    {
        if (_bulletPrefab != null && _firePoint != null)
        {
            try
            {
                if (InventoryManager.Instance.inventoryCells[InventoryManager.Instance.FindItemByName(_ammo)].CurrentItem.Amount > 0)
                {
                    GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
                    InventoryManager.Instance.inventoryCells[InventoryManager.Instance.FindItemByName(_ammo)].CurrentItem.Amount--;
                    InventoryManager.Instance.UpdateCells();
                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddForce(_firePoint.right * _bulletSpeed, ForceMode.VelocityChange);
                    }
                }
            }
            catch( System.Exception e)
            {
                Debug.LogError("Error:" + e.Message);
            }
            
            
            
        }
    }

}