using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;
using SimpleMVC.Routers;
using System.Collections.Generic;
using System.IO;

namespace PizzaMore.App
{
    public static class RouteTable
    {
        public static IEnumerable<Route> Routes
        {
            get
            {
                return new Route[]
                {
                    new Route()
                    {
                        Name = "Custom CSS",
                        Method = RequestMethod.GET,
                        UrlRegex = @"^/css/.+\.css$",
                        Callable = (request) =>
                        {
                            string fileName = request.Url.Substring(request.Url.LastIndexOf('/') + 1);
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText($"../../content/css/{fileName}")
                            };

                            response.Header.ContentType = "text/css";
                            return response;
                        }
                    },
                    new Route()
                    {
                        Name = "Bootstrap Css",
                        Method = RequestMethod.GET,
                        UrlRegex = "/bootstrap/css/bootstrap.min.css$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/css/bootstrap.min.css")
                            };

                            response.Header.ContentType = "text/css";
                            return response;
                        }
                    },
                    new Route()
                    {
                        Name = "Bootstrap Css Map",
                        Method = RequestMethod.GET,
                        UrlRegex = "/bootstrap/css/bootstrap.min.css.map$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/css/bootstrap.min.css.map")
                            };

                            response.Header.ContentType = "text/css";
                            return response;
                        }
                    },
                     new Route()
                {
                    Name = "Images",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/images/.+\..+$",
                    Callable = (request) =>
                    {
                        string imageName = request.Url.Substring(request.Url.LastIndexOf('/') + 1);
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            Content = File.ReadAllBytes($"../../content/images/{imageName}")
                        };
                        response.Header.ContentType = "image/*";

                        return response;
                    }
                },
                    new Route()
                    {
                        Name = "Favicon ico",
                        Method = RequestMethod.GET,
                        UrlRegex = @"/.+\.ico$",
                        Callable = (request) =>
                        {
                            string faviconName = request.Url.Substring(request.Url.LastIndexOf('/') + 1);
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                Content = File.ReadAllBytes($"../../content/{faviconName}")
                            };

                            response.Header.ContentType = "image/x-icon";
                            return response;
                        }
                    },
                     new Route()
                    {
                        Name = "JQuery",
                        Method = RequestMethod.GET,
                        UrlRegex = "/jquery/jquery-3.1.1.js$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../content/jquery/jquery-3.1.1.js")
                            };

                            response.Header.ContentType = "application/x-javascript";
                            return response;
                        }
                    },
                      new Route()
                    {
                        Name = "Bootstrap JS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/bootstrap/js/bootstrap.min.js$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/js/bootstrap.min.js")
                            };

                            response.Header.ContentType = "application/x-javascript";
                            return response;
                        }
                    },
                    new Route()
                    {
                        Name = "Controller/Action/GET",
                        Method = RequestMethod.GET,
                        UrlRegex = @"^/(.+)/(.+)$",
                        Callable = new ControllerRouter().Handle
                    },
                    new Route()
                    {
                        Name = "Controller/Action/POST",
                        Method = RequestMethod.POST,
                        UrlRegex = @"^/(.+)/(.+)$",
                        Callable = new ControllerRouter().Handle
                    }
                };
            }
        }
    }
}
