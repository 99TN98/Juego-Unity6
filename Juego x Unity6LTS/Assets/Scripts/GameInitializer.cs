using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    void Start()
    {

        Screen.SetResolution(800, 480, false); // false = modo ventana
        Debug.Log("Resolución actual: " + Screen.width + "x" + Screen.height);
    }
}
