using UnityEngine;

public class SawScript : MonoBehaviour {

    public float RotateSpeed = -2f;

	void Update () {
        //transform.Rotate(new Vector3(0, 0, 1f));
        transform.Rotate(new Vector3(0, 0, RotateSpeed));
    }
}
