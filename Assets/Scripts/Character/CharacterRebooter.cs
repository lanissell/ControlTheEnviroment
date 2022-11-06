using UnityEngine;

namespace Character
{
    public class CharacterRebooter : MonoBehaviour
    {
        [SerializeField]
        private Character _character;
        [SerializeField]
        private Transform _spawnPosition;

        public void ReloadCharacters()
        {
            DestroyCharacters();
            Instantiate(_character, _spawnPosition);
        }
        
        private void DestroyCharacters()
        {
            Destroy(_spawnPosition.GetChild(0).gameObject);
        }
    }
}
