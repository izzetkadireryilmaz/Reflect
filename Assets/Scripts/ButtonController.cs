using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject laser, laserClone, triangle, square, stick;
    public Canvas DeathCanvas;
    public float rotationSpeed = 45f;
    private bool TriangleRotate = false, SquareRotate = false, StickRotate = false;
    public GameObject star1, star2, star3, star4, star5, star6, star7, star8, star9, star10, star11, star12, star13, star14, star15;

    private void Start()
    {
        laserClone.SetActive(true);
    }
    void Update()
    {
        if (laserClone.activeSelf)
        {
            laser.SetActive(false);
        }
        else
        {
            laser.SetActive(true);
        }

        if (TriangleRotate == true)
        {
            triangle.transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        if (SquareRotate == true)
        {
            square.transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        if (StickRotate == true)
        {
            stick.transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
    public void Active()
    {
        laserClone.SetActive(false);
    }
    public void StartTriangleRotation()
    {
        TriangleRotate = true;
    }
    public void StopTriangleRotation()
    {
        TriangleRotate = false;
    }
    public void StartSquareRotation()
    {
        SquareRotate = true;
    }
    public void StopSquareRotation()
    {
        SquareRotate = false;
    }
    public void StartStickRotation()
    {
        StickRotate = true;
    }
    public void StopStickRotation()
    {
        StickRotate = false;
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
    public void Retry()
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
        DeathCanvas.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    void ActivateStar(ref bool levelCheck, GameObject star)
    {
        if (levelCheck)
        {
            star.SetActive(true);
        }
    }
}
