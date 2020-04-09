using Nancy;
using Nancy.Hosting.Self;
using Nancy.ModelBinding;
using System;

namespace MiniHttp
{
    class Program
    {
        static void Main(string[] args)
        {
            //先建立起監聽器
            NancyHost host = new NancyHost(new Uri("http://localhost:11312"));
            //啟動監聽器
            host.Start();
            Console.WriteLine("再次按下Enter關閉");
            Console.Read();
            host.Stop();

        }
    }
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class MyModule : NancyModule
    {
        public MyModule()
        {
            Get("/", Parameters => { return Response.AsJson("Hello World"); });

            Get("/{MyPara}", Parameters =>
             {
                 return Parameters.MyPara;
             });

            Post("/", Parameters =>
            {
                var Student = this.Bind<Student>();
                return Response.AsJson($"{Student.Id}:{Student.Name}");
            });
        }
    }
}
