using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarGlobals : MonoBehaviour
{
    public struct Sesion
    {
        public int id;
        public int id_user;
        public string codeUser;
        public string nameUser;
        public string lastNameUser;
        public string positionUser;
        public int selection; //
        public int type; //0 Entrena // 1 Evalua 
    }
    public static Sesion sesion = new Sesion();
}
