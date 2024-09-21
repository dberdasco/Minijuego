using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{


    private static MusicPlayer instance = null;

    void Awake()
    {
        // Verificamos si ya existe una instancia de este objeto
        if (instance == null)
        {
            instance = this;
            // No destruir el objeto al cambiar de escena
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si ya existe una instancia, destruimos la nueva para evitar duplicados
            Destroy(gameObject);
        }
    }





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
