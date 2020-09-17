using System;
using System.IO;
using System.Xml;

namespace UnitConverter.Logging.Logging
{
    public static class UCErrorLogger
    {

        //TODO: Add email system to send error logs.

        private const string ERROR_LOG_FILEPATH = ".\\Data\\ErrorLogs.xml";
        public static void LogError(Exception exception)
        {
            DateTime eDate = DateTime.Now;
            string errorBody = exception.Message;

            if (File.Exists(ERROR_LOG_FILEPATH))
            {
                AddErrorRecord(eDate, errorBody);
            }
            else
            {
                CreateXmlLogFile(eDate, errorBody);
            }
        }

        private static void AddErrorRecord(DateTime eDate, string errorBody)
        {
            XmlDocument document = new XmlDocument();
            document.Load(ERROR_LOG_FILEPATH);
            XmlNode error = document.CreateElement("ERROR");
            XmlNode date = document.CreateElement("DATE");
            XmlNode body = document.CreateElement("BODY");

            date.InnerText = eDate.ToShortDateString();
            body.InnerText = errorBody;

            error.AppendChild(date);
            error.AppendChild(body);

            document.DocumentElement.AppendChild(error);
            document.Save(ERROR_LOG_FILEPATH);
        }

        private static void CreateXmlLogFile(DateTime eDate, string errorBody)
        {
            XmlDocument document = new XmlDocument();
            XmlElement root = document.CreateElement("ERRORS");
            document.AppendChild(root);
            document.Save(ERROR_LOG_FILEPATH);

            AddErrorRecord(eDate, errorBody);
        }
    }
}
