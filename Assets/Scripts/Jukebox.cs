using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Jukebox player.
/// </summary>
public sealed class Jukebox : MonoBehaviour
{
    /// <summary>
    /// The organized "discs" of the Jukebox.
    /// </summary>
    /// <value>An indexed Dictionary of at least one <see cref="AudioSource"/> instance.</value>
    private Dictionary<int, AudioSource> Discs { get; set; }    

    /// <summary>
    /// Verify if an specific disc is playing.
    /// </summary>
    /// <param name="index">The index of the disc.</param>
    /// <returns>True if it is playing.</returns>
    public bool IsDiscPlaying(int index)
    {
        if(Disc(index) is null)
        {
            return false;
        }

        return Disc(index).isPlaying;
    }

    /// <summary>
    /// Verify if the disc 1 is playing.
    /// </summary>
    /// <returns>True if it is playing.</returns>
    public bool IsDiscOnePlaying() => DiscOne().isPlaying;

    /// <summary>
    /// Add a disc to the bottom of the disc list.
    /// </summary>
    /// <param name="clip">The new clip of the disc.</param>
    /// <returns>Itself, to run other operations.</returns>
    public Jukebox AddDisc(AudioClip clip)
    {
        ArrangeDiscs();
        
        int index = Discs.Count;

        Discs.Add(index, gameObject.AddComponent<AudioSource>());

        Disc(index).clip = clip;

        return this;
    }

    /// <summary>
    /// Play the given disc.
    /// </summary>
    /// <param name="index">The index of the disc.</param>
    /// <returns>Itself, to run other operations.</returns>
    public Jukebox PlayDisc(int index)
    {
        Disc(index).Play();

        return this;
    }

    /// <summary>
    /// Play the disc 1.
    /// </summary>
    /// <returns>Itself, to run other operations.</returns>
    public Jukebox PlayDiscOne()
    {
        DiscOne().Play();

        return this;
    }

    /// <summary>
    /// Replace an existing disc, or simply put it on the desired position.
    /// </summary>
    /// <param name="index">The index of the disc.</param>
    /// <param name="clip">The new clip of the disc.</param>
    /// <returns>Itself, to run other operations.</returns>
    public Jukebox ReplaceDisc(int index, AudioClip clip)
    {
        ArrangeDiscs();
        
        if(Disc(index) is null)
        {
            Discs.Add(index, gameObject.AddComponent<AudioSource>());
        }

        Disc(index).clip = clip;

        return this;
    }  

    /// <summary>
    /// Stop the given disc.
    /// </summary>
    /// <param name="index">The index of the disc.</param>
    /// <returns>Itself, to run other operations.</returns>
    public Jukebox StopDisc(int index)
    {
        Disc(index).Stop();

        return this;
    }   

    /// <summary>
    /// Stop the disc 1.
    /// </summary>
    /// <returns>Itself, to run other operations.</returns>
    public Jukebox StopDiscOne()
    {
        DiscOne().Stop();

        return this;
    }      

    /// <summary>
    /// Get the referenced disc.
    /// </summary>
    /// <param name="index">The index of the disc.</param>
    /// <returns>The <see cref="AudioSource"/> of the disc.</returns>
    private AudioSource Disc(int index) => Discs[index];
    
    /// <summary>
    /// Get the disc 1.
    /// </summary>
    /// <returns>The <see cref="AudioSource"/> of the disc 1.</returns>
    private AudioSource DiscOne() => Disc(0);

    /// <summary>
    /// Arrange the discs and get the disc 1.
    /// </summary>
    private void ArrangeDiscs()
    {
        if(Discs is null)
        {
            Discs = new Dictionary<int, AudioSource>();

            Discs.Add(0, GetComponent<AudioSource>());
        }
    }

    /// <summary>
    /// The Starter simply arrange the discs.
    /// </summary>
    private void Start() => ArrangeDiscs();
}
