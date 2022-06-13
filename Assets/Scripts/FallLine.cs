using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FallLine : Entity
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Entity>()) {
            collision.gameObject.GetComponent<Entity>().Die();
            SceneManager.LoadScene(0); }
    }
}
