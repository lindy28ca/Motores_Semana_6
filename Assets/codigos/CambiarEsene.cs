using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEsene : MonoBehaviour
{
    public string name;
    public void CambiarScene()
    {
        SceneManager.LoadScene(name);
    }
}
