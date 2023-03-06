using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;


 [RealtimeModel]
    public partial class ScrollViewModel
    {
        [RealtimeProperty(1, true, true)]
        private Vector2 _scrollview;
    }
