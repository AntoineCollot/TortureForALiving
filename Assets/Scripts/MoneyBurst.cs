using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBurst : MonoBehaviour
{
    public float damagesToParticlesRatio = 5;
    ParticleSystem particles;
    ParticleSystem.EmissionModule emission;
    ParticleSystem.Burst burst;
    public static MoneyBurst Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        emission = particles.emission;
        burst = emission.GetBurst(0);
        particles.Stop();
    }

    public void SetParticleByDamages(float amount)
    {
        if (amount <= 0)
            return;
        burst.count = damagesToParticlesRatio * amount;
        emission.SetBurst(0, burst);
    }

    public void Emit()
    {
        particles.Play();
    }
}
