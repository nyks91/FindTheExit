using System;
using NAudio.Wave;

namespace FindTheExit
{
    public class MusicPlayer
    {
        private static string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static string GetFullMusicPath(string musicName)
        {
            string relativeMusicPath = @$"sounds\{musicName}.mp3";
            return Path.Combine(projectDirectory, relativeMusicPath);
        }

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        public void Play(string filePath, float volume = 0.3f)
        {
            Stop();

            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                audioFile = new AudioFileReader(filePath)
                {
                    Volume = volume
                };
                outputDevice.Init(audioFile);
                outputDevice.Play();
            }
        }

        public void Stop()
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
                outputDevice = null;
                audioFile.Dispose();
                audioFile = null;
            }
        }

        public void Pause()
        {
            if (outputDevice != null)
            {
                outputDevice.Pause();
            }
        }

        public void Resume()
        {
            if (outputDevice != null)
            {
                outputDevice.Play();
            }
        }

        public void Loop()
        {
            if (outputDevice != null)
            {
                outputDevice.PlaybackStopped += (sender, e) =>
                {
                    outputDevice.Play();
                };
            }
        }

        public void ChangeVolume(float volume)
        {
            if (audioFile != null)
            {
                audioFile.Volume = volume;
            }
        }
    }
}
