using System.Collections;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public Canvas deathCanvas;
    public float speed = 5f;
    public float rotationSpeed;
    public Vector3 direction;
    public Transform sa�Kenar;
    public Transform solKenar;
    public Transform altKenar;
    public Transform kareAltKenar;
    public Transform kare�stKenar;
    public Transform kareSa�Kenar;
    public Transform kareSolKenar;
    public Transform �ubukSa�Kenar;
    public Transform �ubukSolKenar;
    public float daraltmaA��s� = 15f;

    public void Play()
    {
        direction = transform.up;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        transform.position += direction * speed * Time.deltaTime; // Lazerin hareketini sa�l�yoruz.
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 exitPosition = Vector3.zero;
        Vector3 exitDirection = Vector3.zero;

        if (other.CompareTag("AltKenar"))
        {
            exitPosition = sa�Kenar.position; // hangi kenardan ��kaca��n� belirliyoruz.
            exitDirection = (sa�Kenar.position - altKenar.position).normalized; // ��k�� a��s�n� belirliyoruz.
            StartCoroutine(KenarDevreDisiBirak(sa�Kenar.gameObject)); // d�ng� olu�mamas� i�in ��k�� kenar�n� anl�k kapat�yoruz.
        }
        else if (other.CompareTag("Sa�Kenar"))
        {
            exitPosition = solKenar.position;
            exitDirection = (solKenar.position - sa�Kenar.position).normalized;
            StartCoroutine(KenarDevreDisiBirak(solKenar.gameObject));
        }
        else if (other.CompareTag("SolKenar"))
        {
            exitPosition = altKenar.position;
            exitDirection = (altKenar.position - solKenar.position).normalized;
            StartCoroutine(KenarDevreDisiBirak(altKenar.gameObject));
        }
        else if (other.CompareTag("KareAltKenar"))
        {
            exitPosition = kareSa�Kenar.position;
            exitDirection = (kareSa�Kenar.position - kareAltKenar.position).normalized;
            StartCoroutine(KenarDevreDisiBirak(kareSa�Kenar.gameObject));
        }
        else if (other.CompareTag("KareSa�Kenar"))
        {
            exitPosition = kareAltKenar.position;
            exitDirection = (kareAltKenar.position - kareSa�Kenar.position).normalized;
            StartCoroutine(KenarDevreDisiBirak(kareAltKenar.gameObject));
        }
        else if (other.CompareTag("Kare�stKenar"))
        {
            exitPosition = kareAltKenar.position;
            exitDirection = (kareAltKenar.position - kare�stKenar.position).normalized;
            StartCoroutine(KenarDevreDisiBirak(kareAltKenar.gameObject));
        }
        else if (other.CompareTag("KareSolKenar"))
        {
            exitPosition = kare�stKenar.position;
            exitDirection = (kare�stKenar.position - kareSolKenar.position).normalized;
            StartCoroutine(KenarDevreDisiBirak(kare�stKenar.gameObject));
        }
        else if (other.CompareTag("�ubukSolKenar"))
        {
            exitPosition = �ubukSolKenar.position;
            exitDirection = (this.transform.position - �ubukSolKenar.position).normalized;
            StartCoroutine(KenarDevreDisiBirak(�ubukSolKenar.gameObject));
            StartCoroutine(KenarDevreDisiBirak(�ubukSa�Kenar.gameObject));
        }
        else if (other.CompareTag("�ubukSa�Kenar"))
        {
            exitPosition = �ubukSa�Kenar.position;
            exitDirection = (this.transform.position - �ubukSa�Kenar.position).normalized;
            StartCoroutine(KenarDevreDisiBirak(�ubukSolKenar.gameObject));
            StartCoroutine(KenarDevreDisiBirak(�ubukSa�Kenar.gameObject));
        }
        else if (other.CompareTag("Border"))
        {
            deathCanvas.gameObject.SetActive(true);
        }
        // ��k�� a��s�n� k�smi olarak de�i�tiriyoruz.
        if (exitPosition != Vector3.zero)
        {
            transform.position = exitPosition;
            direction = Daralt�lm��Y�n(exitDirection, daraltmaA��s�);
        }
    }

    // ��k�� a��s�ndaki k�smi de�i�imi yap�yoruz.
    private Vector3 Daralt�lm��Y�n(Vector3 y�n, float daraltmaA��s�)
    {
        float rastgeleA�� = Random.Range(-daraltmaA��s�, daraltmaA��s�); // Daraltma a��s� aral���nda rastgele bir a�� se�iyoruz.
        Quaternion a��D�n��� = Quaternion.Euler(0, 0, rastgeleA��); // D�n�� a��s�n� belirliyoruz.
        return a��D�n��� * y�n;
    }

    private IEnumerator KenarDevreDisiBirak(GameObject kenar)
    {
        kenar.SetActive(false);
        yield return new WaitForSeconds(1f);
        kenar.SetActive(true);
    }
}
