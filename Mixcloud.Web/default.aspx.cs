using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace Mixcloud.Web
{
    public partial class _default : Page
    {
        #region [ RESPONSE CLASSES ]

        public class Paging
        {
            public string previous { get; set; }
        }

        public class Tag
        {
            public string url { get; set; }
            public string name { get; set; }
            public string key { get; set; }
        }

        public class Pictures
        {
            public string medium { get; set; }
            public string extra_large { get; set; }
            public string large { get; set; }
            public string medium_mobile { get; set; }
            public string small { get; set; }
            public string thumbnail { get; set; }
        }

        public class Pictures2
        {
            public string medium { get; set; }
            public string extra_large { get; set; }
            public string large { get; set; }
            public string medium_mobile { get; set; }
            public string small { get; set; }
            public string thumbnail { get; set; }
        }

        public class User
        {
            public string url { get; set; }
            public string username { get; set; }
            public string name { get; set; }
            public string key { get; set; }
            public Pictures2 pictures { get; set; }
        }

        public class Datum
        {
            public int listener_count { get; set; }
            public string name { get; set; }
            public List<Tag> tags { get; set; }
            public string url { get; set; }
            public Pictures pictures { get; set; }
            public string updated_time { get; set; }
            public int play_count { get; set; }
            public int comment_count { get; set; }
            public int percentage_music { get; set; }
            public User user { get; set; }
            public string key { get; set; }
            public string created_time { get; set; }
            public int audio_length { get; set; }
            public string slug { get; set; }
            public int favorite_count { get; set; }
        }

        public class RootObject
        {
            public Paging paging { get; set; }
            public List<Datum> data { get; set; }
            public string name { get; set; }
        }

        #endregion

        private void LoadFavorites()
        {
            try
            {
                string url = string.Format("http://api.mixcloud.com/{0}/favorites/", txtUsername.Text.Trim());

                WebRequest wr = WebRequest.Create(url);
                wr.ContentType = "application/json; charset=utf-8";
                Stream stream = wr.GetResponse().GetResponseStream();
                if (stream != null)
                {
                    StreamReader streamReader = new StreamReader(stream);
                    string jsonString = streamReader.ReadToEnd();

                    var jsonSerializer = new JavaScriptSerializer();
                    RootObject rootObject = jsonSerializer.Deserialize<RootObject>(jsonString);
                    rptFavorites.DataSource = rootObject.data;
                    rptFavorites.DataBind();

                    divFavorites.Visible = rootObject.data.Any();
                    divMessage.Visible = !divFavorites.Visible;
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            LoadFavorites();
        }
    }
}