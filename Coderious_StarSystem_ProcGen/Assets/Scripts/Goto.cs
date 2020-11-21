using UnityEngine;
using TMPro;

public class Goto : MonoBehaviour
{
    public TMP_InputField x, y;
    public Transform cam;

    public void GotoCoordinates()
    {
        cam.position = new Vector3(int.Parse(x.text), int.Parse(y.text), cam.position.z);

        FindObjectOfType<GameManager>().GenerateStars();
    }

}
