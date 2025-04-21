using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTracker : MonoBehaviour
{
    private ARTrackedImageManager trackedImages;
    public GameObject[] ArPrefabs;

    public List<GameObject> ARobjects = new List<GameObject>();

    void Awake()
    {
        trackedImages = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        trackedImages.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        trackedImages.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // Cuando se detecta una imagen nueva
        foreach (var trackedImage in eventArgs.added)
        {
            foreach (var arPrefab in ArPrefabs)
            {
                if (trackedImage.referenceImage.name == arPrefab.name)
                {
                    var newPrefab = Instantiate(arPrefab, trackedImage.transform);
                    ARobjects.Add(newPrefab);
                }
            }
        }

        // Cuando cambia el estado de una imagen (tracking / no tracking)
        foreach (var trackedImage in eventArgs.updated)
        {
            foreach (var gameObject in ARobjects)
            {
                if (gameObject.name == trackedImage.referenceImage.name)
                {
                    bool isTracking = trackedImage.trackingState == TrackingState.Tracking;
                    gameObject.SetActive(isTracking);

                    // Aquí añadimos esta parte para comunicarle al instrumento
                    var instrument = gameObject.GetComponent<InstrumentPlayer>();
                    if (instrument != null)
                    {
                        instrument.SetTracking(isTracking);
                    }
                }
            }
        }
    }
}
