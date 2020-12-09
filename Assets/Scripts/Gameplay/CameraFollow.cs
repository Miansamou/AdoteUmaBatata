using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Potato;
    public float DecelerationSpeed = 0.2f;
    public Vector2 CameraOffSet;

    void LateUpdate() {

        // Access TouchSystem updating the screen size of touch.
        TouchSystem.instance.screenSizeResolution();

        // OffSet in X axis depending on the character rotation.
        if (Potato.rotation.y == 0)
        {
            CameraOffSet.x = -0.8f;
        }
        else
        {
            CameraOffSet.x = 0.8f;
        }

        //FixedPosition is character position + Pre-set offSet.
        Vector2 fixedPosition = (Vector2)Potato.position + CameraOffSet;

        //SlowerPosition is the acceleration from the camera to the character.
        Vector2 slowedPosition = Vector2.Lerp(this.transform.position, fixedPosition, DecelerationSpeed);
        this.transform.position = new Vector3(slowedPosition.x, slowedPosition.y, - 10);

    }

    public void ChangeView(Transform nextView)
    {
        Potato = nextView;
    }

}
