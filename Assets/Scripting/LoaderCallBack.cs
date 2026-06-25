using UnityEngine;

public class LoaderCallBack : MonoBehaviour {

    private bool isFirstUpdate = true;
    private float loadTimer = 1f;

    private void Update() {
        loadTimer -= Time.deltaTime;
        if(isFirstUpdate) {

            if(loadTimer < 0f) {
                isFirstUpdate = false;
            }

            Loader.LoaderCallBack();
        }
    }

}