using System;

using BitMobile.ClientModel3;

namespace Test
{
    public class YandexPhoto
    {
        private static String token = "63b7ea6bd442484093dc4d507a8aa951";
        private static string login = "original-nick";

        public static void SyncPhotos()
        {
            var rst = DB.GetUnsyncedPhotos();
            while (rst.Next())
            {
                String id = rst["Id"].ToString();
                String fileName = rst["FileName"].ToString();
                String link = UploadFile(FileSystem.GetFileStream(fileName));

                if (!String.IsNullOrEmpty(link))
                {
                    DB.MarkPhotoAsSynced(id, link);
                    FileSystem.DeleteFile(fileName);

                    DConsole.WriteLine(String.Format("Photo file {0} has been successfully uploaded", fileName));
                }
            }
        }

        private static String UploadFile(System.IO.Stream fs)
        {
            HttpRequest req = new HttpRequest("http://api-fotki.yandex.ru");
            req.ContentType = "image/jpeg";
            req.AddHeader("Authorization", String.Format("OAuth {0}", token));
            String result = req.Post(String.Format("/api/users/{0}/photos/", login), fs);
            if (req.Status != 200)
            {
                DConsole.WriteLine(req.Error);
                return null;
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);

            var nodes = doc.DocumentElement.ChildNodes;
            foreach (System.Xml.XmlNode node in nodes)
            {
                if (node.Name.Equals("link"))
                    if (node.Attributes["rel"].Value.Equals("self"))
                        return node.Attributes["href"].Value;
            }

            return null; //smth is going wrong...
        }
    }
}
