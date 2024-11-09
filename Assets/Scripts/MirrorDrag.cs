using UnityEngine;

public class MirrorDrag : MonoBehaviour
{
    private Vector3 offset;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }
    void OnMouseDown()
    {
        // Fare ile objeye týklanýnca, fare pozisyonu ile obje arasýndaki farký hesaplar
        offset = transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
    }

    void OnMouseDrag()
    {
        // Objenin fare ile sürüklenmesini saðlar
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane);
        transform.position = cam.ScreenToWorldPoint(newPosition) + offset;
    }

}
