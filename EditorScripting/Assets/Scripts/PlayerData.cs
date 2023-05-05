using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// custom class를 unity가 직렬화해서 serialized property로 만들고
// 그것을 drawing 하는 순간에 unity 기본 드로잉 방식이 아니라 원하는 방식대로 그리게 만드는 방법

public enum PlayerClass
{ 
    Warrior,
    Magician
}


[Serializable]
public class PlayerData
{
    public int hp;
    public string name;
    public PlayerClass thisClass;
}

