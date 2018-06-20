using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Risk.API.Helper
{
    public static class ExcelResponseHelper
    {
        public static HttpResponseMessage Create(Stream stream, string fileName, string mediaType, string t_userAgent, HttpStatusCode httpStatusCode)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            ////excelStream.Position = 0; "application/octet-stream"

            stream.Seek(0, SeekOrigin.Begin);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");

            ////IE

            if (Regex.IsMatch(t_userAgent, @"\bMSIE\b", RegexOptions.IgnoreCase))
            {
                response.Content.Headers.ContentDisposition.FileName = HttpUtility.UrlPathEncode(fileName);
            }

            ////FireFox or Opera

            else if (Regex.IsMatch(t_userAgent, @"\bmozilla|opera\b", RegexOptions.IgnoreCase))
            {
                response.Content.Headers.ContentDisposition.FileNameStar = fileName;    ////UTF-8''<p_filename>
            }

            ////Safari
            else if (Regex.IsMatch(t_userAgent, @"\bSafari\b", RegexOptions.IgnoreCase))
            {
                Encoding t__iso = Encoding.GetEncoding("ISO-8859-1");
                byte[] t__utfBytes = Encoding.UTF8.GetBytes(fileName);
                byte[] t__isoBytes = Encoding.Convert(Encoding.UTF8, t__iso, t__utfBytes);
                response.Content.Headers.ContentDisposition.FileName = t__iso.GetString(t__isoBytes);
            }

            ////Chrome

            else if (Regex.IsMatch(t_userAgent, @"\bapplewebkit\b", RegexOptions.IgnoreCase))
            {
                response.Content.Headers.ContentDisposition.FileName = Convert.ToBase64String(Encoding.UTF8.GetBytes(fileName));
            }
            else
            {
                response.Content.Headers.ContentDisposition.FileName = HttpUtility.UrlPathEncode(fileName);
                response.Content.Headers.ContentDisposition.FileNameStar = fileName;
            }

            return response;
        }
    }
}
