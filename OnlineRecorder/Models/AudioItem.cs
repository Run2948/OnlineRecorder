using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineRecorder.Models
{
    public class AudioItem
    {
        public AudioItem()
        {
        }

        public AudioItem(string title, string wav)
        {
            this.title = title;
            this.wav = wav;
        }

        public string title { get; set; }
        public string wav { get; set; }

    }

    public class AudioDao
    {
        public static List<AudioItem> all = new List<AudioItem>();

        public static List<AudioItem> GetAllItems()
        {
            return all;
        }

        public static void AddItem(AudioItem item)
        {
            all.Add(item);
        }
    }

}