using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string projectRoot = @"D:\repos\HospitalManagement\Core\HospitalManagement.Domain";
        string globalUsingsPath = Path.Combine(projectRoot, "GlobalUsings.cs");

        try
        {
            var namespaces = Directory.GetFiles(projectRoot, "*.cs", SearchOption.AllDirectories)
                .Where(file => !file.EndsWith("GlobalUsings.cs"))
                .SelectMany(file => File.ReadLines(file)
                .Where(line => line.StartsWith("namespace "))
                .Select(line => line.Substring(10).Trim().Split('{')[0].Trim()))
                .Distinct()
                .OrderBy(ns => ns);

            using (var fileStream = new FileStream(globalUsingsPath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var writer = new StreamWriter(fileStream))
            {
                writer.WriteLine("// Auto-generated global using directives");
                writer.WriteLine("global using System;");
                writer.WriteLine("global using System.Text;");
                writer.WriteLine("global using System.Reflection;");
                writer.WriteLine("global using System.Collections.Generic;");
                writer.WriteLine("global using System.Linq;");
                writer.WriteLine("global using System.Linq.Expressions;");
                writer.WriteLine("global using System.Threading.Tasks;");
                writer.WriteLine("global using System.Linq.Dynamic.Core;");
                writer.WriteLine("global using Microsoft.EntityFrameworkCore;");
                writer.WriteLine("global using Microsoft.Extensions.DependencyInjection;");
                writer.WriteLine("global using FluentValidation;");
                writer.WriteLine("global using MediatR;");
                writer.WriteLine("global using AutoMapper;");
                writer.WriteLine("global using LinqKit;");

                foreach (var ns in namespaces)
                {
                    writer.WriteLine($"global using {ns};");
                }
            }

            Console.WriteLine("GlobalUsings.cs dosyası oluşturuldu.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Bir IO hatası oluştu: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Bir hata oluştu: {ex.Message}");
        }
    }
}
