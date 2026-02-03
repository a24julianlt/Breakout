using UnityEngine;
using System.Collections.Generic;

public class PelotaController1 : MonoBehaviour
{
    [SerializeField] AudioClip sfxPaddel;  // Sonido al chocar con la pala
    [SerializeField] AudioClip sfxBrick;   // Sonido al chocar con un ladrillo
    [SerializeField] AudioClip sfxWall;    // Sonido al chocar con una pared
    [SerializeField] AudioClip sfxFail;    // Sonido al salir por la pared inferior

    [SerializeField] float delay;
    [SerializeField] float force;

    // Estructura donde almacenaremos las etiquetas y la puntuación de cada ladrillo
    Dictionary<string, int> ladrillos = new Dictionary<string, int>(){
    {"Ladrillo-Amarillo", 10},
    {"Ladrillo-Verde", 15},
    {"Ladrillo-Naranja", 20},
    {"Ladrillo-Rojo", 25},
    };

    Rigidbody2D rb;
    AudioSource sfx;  // Componente AudioSource

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sfx = GetComponent<AudioSource>();
        Invoke("LanzarPelota", delay);
    }
    private void LanzarPelota()
    {
        transform.position = Vector3.zero;
        rb.linearVelocity = Vector2.zero;

        float dirX, dirY = -1;
        dirX = Random.Range(0, 2) == 0 ? -1 : 1;
        Vector2 dir = new Vector2(dirX, dirY);
        dir.Normalize();

        rb.AddForce(dir * force, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Almacenamos la etiqueta del objeto con el que estamos colisionando
        string tag = other.gameObject.tag;

        if (tag == "Pala")
        {
            sfx.clip = sfxPaddel;
            sfx.Play();

        }
        else if (ladrillos.ContainsKey(tag))
        {
            sfx.clip = sfxBrick;
            sfx.Play();
        }
        else if (tag == "wall-R" || tag == "wall-L" || tag == "wall-T")
        {
            sfx.clip = sfxWall;
            sfx.Play();
        }
    }

}