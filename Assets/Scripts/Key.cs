using System.Collections;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject doorToOpen;               // Door that the key opens
    Vector3 startingScale;                      // starting size of the doorToOpen
    Player player;
    public float doorOpenTime = 1f;             // time it takes to open up the door

    void Start()
    {
        startingScale = doorToOpen.transform.localScale;
        player = GameObject.FindObjectOfType<Player>();
        player.OnKeyFound += OpenDoor;
        player.OnPlayerDeath += RespawnKeyAndDoor;
    }

    void OpenDoor()
    {
        HideKey();
        StartCoroutine(ShrinkAndDelete(doorToOpen));
    }

    IEnumerator ShrinkAndDelete(GameObject obj)
    {
        Vector3 targetScale = Vector3.zero;
        float elapsedTime = 0f; 
       
        while (elapsedTime < doorOpenTime)
        {
            float currentX = Mathf.Lerp(startingScale.x, targetScale.x, elapsedTime / doorOpenTime);

            obj.transform.localScale = new Vector3(currentX, obj.transform.localScale.y, obj.transform.localScale.z); // Lerp(startingScale, targetScale, elapsedTime / doorOpenTime);
            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
    }

    void HideKey()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }

    void RespawnKeyAndDoor()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;

        doorToOpen.transform.localScale = startingScale;
    }

}
