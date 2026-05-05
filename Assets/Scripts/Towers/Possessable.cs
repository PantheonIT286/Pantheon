using System.Collections;
using UnityEngine;

public class Possessable : MonoBehaviour
{
    public Transform cameraAnchor;
    public float transitionTime = 0.3f;

    private void Awake()
    {
        if (cameraAnchor == null)
        {
            cameraAnchor = transform.Find("CameraAnchor");
        }
    }

    public void EnterPossession()
    {
        Debug.Log("ENTER POSSESSION on: " + name + " | Frame: " + Time.frameCount);
        Debug.Log($"{name} anchor = {cameraAnchor}");
        if (cameraAnchor == null)
        {
            Debug.LogError($"{name}: Missing cameraAnchor!");
            return;
        }

        Transform playerRoot = CameraManager.Instance.fpsCamera.transform.parent;

        GameStateManager.Instance.StartCoroutine(
            SmoothTransition(playerRoot)
        );
    }

    IEnumerator SmoothTransition(Transform playerRoot)
    {
        Vector3 startPos = playerRoot.position;
        Quaternion startRot = playerRoot.rotation;

        float elapsed = 0f;

        while (elapsed < transitionTime)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / transitionTime;

            playerRoot.position = Vector3.Lerp(startPos, cameraAnchor.position, t);
            playerRoot.rotation = Quaternion.Slerp(startRot, cameraAnchor.rotation, t);

            yield return null;
        }

        playerRoot.position = cameraAnchor.position;
        playerRoot.rotation = cameraAnchor.rotation;

        GameStateManager.Instance.SetState(GameState.PossessionMode);
    }
}