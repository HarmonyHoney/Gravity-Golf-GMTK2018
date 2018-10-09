using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour {

    [SerializeField] private float lifetime;

    private void Update() {

        lifetime -= Time.deltaTime;

        if (lifetime < 0f) {

            Destroy(gameObject);
        }

    }
}
