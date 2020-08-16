using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Bullet isimli prefabımıza ekli script...
public class Bullet : MonoBehaviour
{
    void Start()
    {
        // Atılan merminin belli bir süre sonra yok olması.
        Destroy(gameObject, 70f * Time.deltaTime);
    }
}
