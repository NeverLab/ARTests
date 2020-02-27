using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.XR;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class ARController : MonoBehaviour
{
    public ARTrackedImageManager arTrackedImageManager;
    public Text status;


    public void OnTrackedChanged(ARTrackedImagesChangedEventArgs images)
    {
        string s = $"";
        foreach (var a in images.added)
        {
            s += $"Target named {a.name} added.\n";
        }
        foreach (var a in images.removed)
        {
            s += $"Target named {a.name} removed.\n";
        }
        foreach (var a in images.updated)
        {
            s += $"Target named {a.name} updated.\n";
        }
        status.text = s;
    }

    // Start is called before the first frame update
    async void Start()
    {
        //arTrackedImageManager.referenceLibrary = await Addressables.LoadAssetAsync<IReferenceImageLibrary>(libraryReference).Task;
        arTrackedImageManager.trackedImagesChanged += OnTrackedChanged;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
