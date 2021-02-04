using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

    public GameObject explosionPrefab;
    private GameObject explosion;
    bool exploding = false;
    public bool explodingRead;
    public string colorDescriptor;
    public int maxParticle;
    private Color32 colors;

    public void Explode(Vector3 pos)
    {
        pos = new Vector3(pos.x, pos.y, pos.z + 50);
        explosion = Instantiate(explosionPrefab, pos, Quaternion.Euler(0f, 0f, 0f));
        exploding = true;
    }
    void Update()
    {
        if (explodingRead)
        {
            Explode(gameObject.transform.position);
            explodingRead = false;
        }
    }
    private void LateUpdate()
    {
        
        if (exploding)
        {
            ParticleSystem explosionParticleSystem = explosion.GetComponent<ParticleSystem>();
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[explosionParticleSystem.main.maxParticles];
            colors = GetComponent<Renderer>().material.color;
            

            int numParticlesAlive = explosionParticleSystem.GetParticles(particles);
            for (int i = 0; i < numParticlesAlive; i++)
            {
                particles[i].startColor = colors;
            }

            explosionParticleSystem.SetParticles(particles, numParticlesAlive);
            exploding = false;

            Destroy(gameObject);
        }
    }
}