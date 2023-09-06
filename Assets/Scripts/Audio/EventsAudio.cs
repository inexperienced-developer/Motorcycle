using System;

public static class EventsAudio
{
    public static Action<string, float> ChangeAudioVolume;
    public static void OnChangeAudioVolume(string key, float volume) => ChangeAudioVolume?.Invoke(key, volume);
}
