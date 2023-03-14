// See https://aka.ms/new-console-template for more information

// Create an HTTP request to a JSON API endpoint
using System.Net;

HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://pipes2.kan.org.il/api/item?tagId=137");
request.Method = "GET";

// Send the request and get the response
HttpWebResponse response = (HttpWebResponse)request.GetResponse();
Stream dataStream = response.GetResponseStream();
StreamReader reader = new StreamReader(dataStream);
string responseFromServer = reader.ReadToEnd();

// Write the response to a JSON file
File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "response.json"), responseFromServer);
