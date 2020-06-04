using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class BreakableObject : MonoBehaviour
{
    [Header("Loot")]
    public int dropNumber;
    public int lootRange;
    public GameObject[] myLoot;
	public GameObject[] coeur;

    [Header ("Audio")]
    public AudioClip breakAudio;
    public AudioClip breakAudio2;
    public AudioClip breakAudio3;
    public AudioClip NarratorVoice48;
    //GameManager.Instance.loot(dropNumber, lootRange, myLoot);




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword" || collision.tag == "Slam")
        {
            int token = Random.Range(1, 4);
            switch (token)
            {
                case (1):
                    SoundManager.instance.PlaySfx(breakAudio, 0.3f, 1);
                    break;

                case (2):
                    SoundManager.instance.PlaySfx(breakAudio2, 0.3f, 1);
                    break;

                case (3):
                    SoundManager.instance.PlaySfx(breakAudio3, 0.3f, 1);
                    break;

            }

            GameManager.Instance.loot(dropNumber, lootRange, myLoot, this.gameObject);
			GameManager.Instance.loot(1, lootRange, coeur, this.gameObject);




            if (!SoundManager.instance.voice48 && !SoundManager.instance.voiceSource.isPlaying)
            {
                SoundManager.instance.PlayVoices(NarratorVoice48, 1);
                SoundManager.instance.voice48 = true;
            }




            Destroy(gameObject);
        }
    }
}
