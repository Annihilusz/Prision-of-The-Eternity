using System.Collections;
using UnityEngine;

namespace CreatingCharacters.Abilities
{
    public abstract class Ability : MonoBehaviour
    {
        public abstract IEnumerator Cast();
    }
}