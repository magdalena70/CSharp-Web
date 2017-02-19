using SharpStore.Data;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace SharpStore.Data
{
    public static class RoutesConfig
    {
        public static IList<Route> UseRoutes()
        {
            var routes = new List<Route>()
            {
                //post message
                new Route()
                {
                    Name = "Post Directory",
                    Method = SimpleHttpServer.Enums.RequestMethod.POST,
                    UrlRegex = @"^/.+\.html$",
                    Callable = (request) =>
                    {
                        MessageSender.AddToDatabase(request.Url, request.Content);
                        var fileName = request.Url.Substring(1);
                        return new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText($"../../content/{fileName}")
                        };
                    }
                },
                //get html page
                new Route()
                {
                    Name = "Get Html Directory",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = @"^/.+\.html\?*.*$",
                    Callable = (request) =>
                    {
                        //find name of file
                        int startIndexFileName = request.Url.LastIndexOf('/')+1;
                        int lastIndexFileName = request.Url.IndexOf(".html")+5;
                        int fileNameLength = lastIndexFileName - startIndexFileName;
                        string fileName = request.Url.Substring(startIndexFileName, fileNameLength);

                        //find name of theme from query string
                        int startindexchangestylequery = request.Url.LastIndexOf(".html")+5;
                        string styleKey = request.Url.Substring(startindexchangestylequery).Split('=')[0];
                        string styleValue = null;

                        if (styleKey == "?theme")
                        {
                            styleValue = request.Url.Substring(startindexchangestylequery).Split('=')[1];
                        }

                        //find name of poducts from query string
                        int startIndexSearchQuery = request.Url.LastIndexOf(".html")+5;
                        string searhKey = request.Url.Substring(startIndexSearchQuery).Split('=')[0];
                        string searchValue = request.Header.Cookies["theme"].Value;
                        if (searhKey == "?product-name")
                        {
                            searchValue = request.Url.Substring(startIndexSearchQuery).Split('=')[1];
                        }

                        //response
                        var response = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok
                        };

                        response.Header.Cookies.Add(new Cookie("theme", styleValue));
                        Cookie cookie = request.Header.Cookies["theme"];
                        
                        if (fileName == "products.html")
                        {
                            response.ContentAsUTF8 = ProductLoader.GetProduct(searchValue, styleValue);
                        }
                        else
                        {
                            //ContentAsUTF8 = File.ReadAllText($"../../content/{fileName}")
                            var newStyle = StyleChenger.InsertStyle($"../../content/{fileName}", $"../../content/css/{cookie.Value}.css");
                            response.ContentAsUTF8 = newStyle;
                        }

                        Console.WriteLine(response.ToString());
                        return response;
                    }
                },
                //images
                new Route()
                {
                    Name = "Get Images Directory",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = @"^/images/.+$",
                    Callable = (request) =>
                    {
                        var imageName = request.Url.Substring(1);

                        var response = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            Content = File.ReadAllBytes($"../../content/{imageName}")
                        };
                        response.Header.ContentType = "image/*";
                        request.Header.ContentLength = response.Content.Length.ToString();
                        return response;
                    }
                },

                //css
                new Route()
                {
                    Name = "Get Custom CSS Directory",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = @"^/content/css/.+\.css$",
                    Callable = (request) =>
                    {
                        var styleName = request.Url.Substring(1);
                        var response = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            Content = File.ReadAllBytes($"../../{styleName}")
                        };
                        response.Header.ContentType = "text/css";
                        request.Header.ContentLength = response.Content.Length.ToString();
                        return response;
                    }
                },

                new Route()
                {
                    Name = "Get Bootstrap CSS Directory",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = @"^/bootstrap/css/.+$",
                    Callable = (request) =>
                    {
                        var styleName = request.Url.Substring(1);
                        var response = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            Content = File.ReadAllBytes($"../../content/{styleName}")
                        };
                        response.Header.ContentType = "text/css";
                        request.Header.ContentLength = response.Content.Length.ToString();
                        return response;
                    }
                },
                //js
                new Route()
                {
                    Name = "Get Bootstrap JS",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = @"^/bootstrap/js/.+\.js$",
                    Callable = (request) =>
                    {
                        var jsFileName = request.Url.Substring(1);
                        var response = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText($"../../content/{jsFileName}")
                        };
                        response.Header.ContentType = "application/x-javascript";
                        return response;
                    }
                }
            };

            return routes;
        }
    }
}
