// Decompiled with JetBrains decompiler
// Type: Elibom.APIClient.RestClient

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace PortalSac.APIClient
{
  public class RestClient
  {
    private string URL = "https://falabellape-portalsacapi.azurewebsites.net/";
    private string version = "csharp-1.0.6";
    private string User;
    private string Token;

    public RestClient(string user, string token)
    {
      this.User = user;
      this.Token = token;
    }

    public RestClient() { }

    public object get(string resource, Dictionary<string, string> data)
    {
      return this.executeRequest(this.createRequest(resource, "GET", data));
    }

    public object post(string resource, object data)
    {
      return this.executeRequest(this.createRequest(resource, "POST", data));
    }

    public object delete(string resource, Dictionary<string, string> data)
    {
      return this.executeRequest(this.createRequest(resource, "DELETE", data));
    }

    private HttpWebRequest createRequest(
      string resource,
      string method,
      object data)
    {
      HttpWebRequest request = (HttpWebRequest) WebRequest.Create(this.URL + resource);
      request.Method = method;
      request.KeepAlive = false;
      request.ServicePoint.Expect100Continue = false;
      this.setAuthorizationHeader(request);
      request.ContentType = "text/json";
      if (data != null)
        this.setJsonToRequest(this.dataToString(data), request.GetRequestStream());
      return request;
    }

    protected void setAuthorizationHeader(HttpWebRequest request)
    {
      string str = RestClient.EncodeTo64(this.User + ":" + this.Token);
      request.Headers["Authorization"] = "Basic " + str;
      request.Headers["X-API-Source"] = this.version;
    }

    protected static string EncodeTo64(string toEncode)
    {
      return Convert.ToBase64String(Encoding.UTF8.GetBytes(toEncode));
    }

    protected virtual void setJsonToRequest(string json, Stream stream)
    {
      StreamWriter streamWriter = new StreamWriter(stream);
      streamWriter.Write(json);
      streamWriter.Flush();
      streamWriter.Close();
    }

    protected string responseAsString(Stream stream)
    {
      return new StreamReader(stream).ReadToEnd();
    }

    protected object buildDynamic(string body)
    {
      return new JavaScriptSerializer().Deserialize<object>(body);
    }

    protected string dataToString(object data)
    {
      StringBuilder output = new StringBuilder();
      new JavaScriptSerializer().Serialize((object) data, output);
      return output.ToString();
    }

    protected virtual object executeRequest(HttpWebRequest request)
    {
      return this.buildDynamic(this.responseAsString(request.GetResponse().GetResponseStream()));
    }
  }
}
