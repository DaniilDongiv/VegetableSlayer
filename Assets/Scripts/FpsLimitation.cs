using UnityEngine;

public class FpsLimitation : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = -1;
    }
}
