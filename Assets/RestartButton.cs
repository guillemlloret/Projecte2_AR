using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public ImageTracker tracker;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestButton()
    {
       
        foreach (var prefab in tracker.ARobjects)
        {
            if (prefab != null)
            {
                Destroy(prefab);



            }
        }
        tracker.ARobjects.Clear();
        //SceneManager.LoadScene("MusicGame");

    }

   
}
