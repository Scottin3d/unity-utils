using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.UnityServiceLocator.Tests
{
    public interface ILocalization{
        string GetLocalizedWord(string key);
    }

    public class MockServiceLocator : ILocalization{
        readonly List<string> words = new List<string> {
            "Hello",
            "World"
        };

        readonly System.Random random = new System.Random();

        public string GetLocalizedWord(string key){
            return words[random.Next(words.Count)];
        }
    }
    public interface ISerializer{
        void Serialize();
    }

    public class MockSerializer : ISerializer{
        public void Serialize(){
            Debug.Log("MockSerializer.Serialize: Serialized data");
        }
    }

    public interface IAudioService{
        void Play();
    }

    public class MockAudioService : IAudioService{
        public void Play(){
            Debug.Log("MockAudioService.Play: Playing audio");
        }
    }

    public interface IGameService{
        void Start();
    }

    public class MockGameService : IGameService{
        public void Start(){
            Debug.Log("MockGameService.StartGame: Game started");
        }
    }

    public class MockMapService : IGameService{
        public void Start(){
            Debug.Log("MockMapService.StartGame: Map started");
        }
    }
}
