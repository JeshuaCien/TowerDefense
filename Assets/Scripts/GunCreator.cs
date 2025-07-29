using UnityEngine;

public class GunCreator : MonoBehaviour
{
    [SerializeField]
    private float _raycastDistance = 10f;

    [SerializeField]
    private LayerMask _layerMask;

    [SerializeField]
    private string _floortag = "floor";
    private bool _gunPlaced = false;

    private Transform _gun;

    private void Update()
    {
        if (_gun == null) return;
        if (Input.GetMouseButton(0))
        {
            PlaceGun();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (!_gunPlaced)
            {
                _gun.gameObject.SetActive(false);
            }
            _gun = null;
        }
        if (Input.GetMouseButtonDown(1))
        {
            _gun.gameObject.SetActive(false);
            _gun = null;
        }
    }

    private void PlaceGun()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, _raycastDistance, _layerMask))
        {
            if (hit.collider.CompareTag(_floortag) && _gun != null)
            {
                _gun.position = hit.point;
                _gunPlaced = true;
            }
        }
    }

    public void SetGun(Transform gun)
    {
        _gun = gun;
        _gunPlaced = false;
    }
}
