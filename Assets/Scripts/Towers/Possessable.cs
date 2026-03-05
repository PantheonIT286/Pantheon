using System.Collections;
using UnityEngine;

public class Possessable : MonoBehaviour
{
    public Transform cameraAnchor;
    public float transitionTime = 0.3f;

    public void EnterPossession()
    {
        GameStateManager.Instance.StartCoroutine(
            SmoothTransition(GameStateManager.Instance.fpsCamera.transform)
        );
    }

    IEnumerator SmoothTransition(Transform cam)
    {
        GameStateManager.Instance.SetState(GameState.PossessionMode);

        Vector3 startPos = cam.position;
        Quaternion startRot = cam.rotation;

        float elapsed = 0f;

        while (elapsed < transitionTime)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / transitionTime;

            cam.position = Vector3.Lerp(startPos, cameraAnchor.position, t);
            cam.rotation = Quaternion.Slerp(startRot, cameraAnchor.rotation, t);

            yield return null;
        }

        cam.position = cameraAnchor.position;
        cam.rotation = cameraAnchor.rotation;
    }
}