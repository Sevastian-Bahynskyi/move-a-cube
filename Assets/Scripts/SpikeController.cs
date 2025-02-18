using System.Collections;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Time it takes to complete one movement
    [SerializeField] private Vector3 spikeSize = new Vector3(0.5f, 5f, 0.5f);
    [SerializeField] private float pauseDuration = 0.1f; // Pause duration at the end of each movement

    private Vector3 originalPosition;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        targetPosition = new Vector3(originalPosition.x, originalPosition.y + spikeSize.y, originalPosition.z);
        StartCoroutine(SpikeCycle());
    }

    private void OnValidate()
    {
        transform.localScale = spikeSize;
        transform.position = new Vector3(transform.position.x, -spikeSize.y / 2 - 0.1f, transform.position.z);
    }

    private IEnumerator SpikeCycle()
    {
        while (true)
        {
            yield return StartCoroutine(MoveSpike(originalPosition, targetPosition, speed));
            yield return new WaitForSeconds(pauseDuration); // Short pause at the top

            yield return StartCoroutine(MoveSpike(targetPosition, originalPosition, speed));
            yield return new WaitForSeconds(pauseDuration); // Short pause at the bottom
        }
    }

    private IEnumerator MoveSpike(Vector3 startPosition, Vector3 endPosition, float speed)
    {
        float distance = Vector3.Distance(startPosition, endPosition);
        float duration = distance / speed;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;
    }
}