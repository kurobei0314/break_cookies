using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public static class GameInfo{

        // クッキーを作成する総数
        public static readonly float COOKIE_NUM = 30;

        //　クッキーの大きさの範囲
        public static readonly float MIN_COOKIE_SCALE = 1.0f;
        public static readonly float MAX_COOKIE_SCALE = 2.0f;

        //　ゲームの時間
        public static readonly float GAME_TIME = 30;

        //円のスピードの最小値、最大値
        public static readonly float MIN_SPEED = 0.01f;
        public static readonly float MAX_SPEED = 0.05f;

        public static readonly float MAX_CSIZE = 1.5f;

    }

    //ブロックの色を管理する
    public static class NoteInfo{
        public enum CookieKind{
            COOKIE1,
            COOKIE2,
        }
    }
