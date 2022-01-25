using System;
using System.Linq;
using Blog.Data;
using Blog.Models;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new BlogDataContext())
            {
                //CREATE
                // var tag = new Tag{Name="SUCRILHOS", Slug="sucrilhos"};
                // context.Tags.Add(tag);
                // context.SaveChanges();

                //UPDATE
                // var tag = context.Tags.FirstOrDefault(x=>x.Id == 3);
                // tag.Name = ".NET";
                // tag.Slug = "dotnet";
                // context.Tags.Update(tag);
                // context.SaveChanges();

                //DELETE
                var tag = context.Tags.FirstOrDefault(x=>x.Id == 3);
                context.Remove(tag);
                context.SaveChanges();
            }
        }
    }
}
