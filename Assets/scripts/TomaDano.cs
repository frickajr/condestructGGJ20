using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomaDano : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "perigo")
        {
            StartCoroutine(Pisca());
        }
    }

    IEnumerator Pisca()
    {
        float newX = transform.position.x - 5f;
        spriteRenderer.color = new Color32(255, 92, 45, 255);
        if (newX < 0f) newX = 0f;
        transform.position = new Vector3(newX, 0f, 0f);
        for (var i = 0; i < 10; i++)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(0.3f);
        }
        spriteRenderer.color = new Color32(255, 255, 255, 255);
    }
}
