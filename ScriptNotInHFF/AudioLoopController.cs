using System;
using UnityEngine;

public class AudioLoopController : MonoBehaviour
{
	public void Play()
	{
		this.start.PlayDelayed(this.startDelay);
		this.loop.PlayDelayed(this.startDelay + this.start.clip.length);
	}

	public void Pause()
	{
		this.loop.Pause();
		this.end.Play();
	}

	public void Stop()
	{
		this.loop.Stop();
		this.end.Play();
	}

	public void StopImmediately()
	{
		this.start.Stop();
		this.loop.Stop();
		this.end.Stop();
	}

	public AudioSource start;

	public AudioSource loop;

	public AudioSource end;

	public float startDelay = 1f;

	public enum LoopControl
	{
		OnStop_StopLoop,
		OnStop_PauseLoop
	}
}
