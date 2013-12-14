using UnityEngine;
using System.Collections;

public class EffectsScript : MonoBehaviour {

    public static EffectsScript Instance;

    public ParticleSystem splash;

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsHelper!");
        }

        Instance = this;
    }

    public void Splash(Vector3 position)
    {

        instantiate(splash, position);
    }
    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(
          prefab,
          position,
          Quaternion.identity
        ) as ParticleSystem;

        Destroy(
          newParticleSystem.gameObject,
          newParticleSystem.startLifetime
        );

        return newParticleSystem;
    }
}
