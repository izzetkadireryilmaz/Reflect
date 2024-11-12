using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserController : MonoBehaviour
{
    public Canvas deathCanvas, gameCanvas;
    public float speed = 5f, rotationSpeed, daraltmaA��s� = 15f;
    public Vector3 direction;
    public Transform sa�Kenar, solKenar, altKenar, kareAltKenar, kare�stKenar, kareSa�Kenar, kareSolKenar, �ubukSa�Kenar, �ubukSolKenar;
    public static bool canvasBool = false;
    public GameObject star1, star2, star3, star4, star5, star6, star7, star8, star9, star10, star11, star12, star13, star14, star15;

    private void Start()
    {
        ActivateStar(ref MenuManager.level1b, star1);
        ActivateStar(ref MenuManager.level2b, star2);
        ActivateStar(ref MenuManager.level3b, star3);
        ActivateStar(ref MenuManager.level4b, star4);
        ActivateStar(ref MenuManager.level5b, star5);
        ActivateStar(ref MenuManager.level6b, star6);
        ActivateStar(ref MenuManager.level7b, star7);
        ActivateStar(ref MenuManager.level8b, star8);
        ActivateStar(ref MenuManager.level9b, star9);
        ActivateStar(ref MenuManager.level10b, star10);
        ActivateStar(ref MenuManager.level11b, star11);
        ActivateStar(ref MenuManager.level12b, star12);
        ActivateStar(ref MenuManager.level13b, star13);
        ActivateStar(ref MenuManager.level14b, star14);
        ActivateStar(ref MenuManager.level15b, star15);
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
        else if (other.CompareTag("Level1_Star"))
        {
            int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
            currentLevel += 1;
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);

            for (int i = 2; i <= 15; i++)
            {
                if (PlayerPrefs.GetInt("CurrentLevel") <= i - 1)
                {
                    PlayerPrefs.SetInt("Level" + i, 1);
                    Debug.Log(i);
                    break;
                }
            }
            canvasBool = true;
            SceneManager.LoadScene(0);
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

    public void Play()
    {
        direction = transform.up;
        gameCanvas.gameObject.SetActive(false);
    }

    void ActivateStar(ref bool levelCheck, GameObject star)
    {
        if (levelCheck)
        {
            star.SetActive(true);
        }
    }
}
