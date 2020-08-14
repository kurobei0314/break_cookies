using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public static class GameInfo{

        // クッキーを作成する総数
        public static readonly float COOKIE_NUM = 10;

        //　ゲームの時間
        public static readonly float GameTime = 30;


    }

    //ブロックの色を管理する
    public static class NoteInfo{
        public enum CookieKind{
            COOKIE1,
            COOKIE2,
        }
    }
