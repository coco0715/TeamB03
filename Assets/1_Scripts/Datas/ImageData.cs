using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ImageDatas
{
    [System.Serializable]
    public class ImageData
    {
        public string imgName;
    }

    [System.Serializable]
    public class ImageInfo
    {
        public List<ImageData> ImageDataList;
    }
}
