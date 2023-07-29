using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Sounds", menuName = "ScriptableObject/Sounds")] 
public class Audioclips : ScriptableObject 
{
    public AudioClip Jump;
    public AudioClip Death;
    public AudioClip Dash;
    public AudioClip Damage;
    public AudioClip Attack;
    }
