using UnityEngine;

public class ChestOpenTrigger : MonoBehaviour
{
    [SerializeField] private Chest _chest;

    private bool _isOpened = false;
    private bool _HasOpener;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ChestOpener>())
        {
            _HasOpener = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ChestOpener>())
        {
            _HasOpener = false;
        }
    }

    private void Update()
    {
        if (_isOpened)
            return;

        if(_HasOpener && Input.GetKeyDown(KeyCode.E))
        {
            _chest.Open();
            _isOpened = true;
        }
    }
}
