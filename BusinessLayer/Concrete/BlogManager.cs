using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager
    {
        Repository<Blog> repoBlog = new Repository<Blog>();

        public List<Blog> GetAll()
        {
            return repoBlog.List();
        }
        public List<Blog> GetBlogById(int id)
        {
            return repoBlog.List(x => x.BlogId == id);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return repoBlog.List(x => x.AuthorId == id);
        }

        public List<Blog> GetBlogByCategory(int id)
        {
            return repoBlog.List(x => x.CategoryId == id);
        }
        public int BlogAdd(Blog blog)
        {
            if(blog.BlogTitle=="" || blog.BlogImage=="" || blog.BlogContent=="")
            {
                return -1;
            }
            return repoBlog.Insert(blog);
        }
        public int DeleteBlog(int p)
        {
            Blog blog = repoBlog.Find(x => x.BlogId == p);
            return repoBlog.Delete(blog);
        }

        public Blog FindBlog(int id)
        {
            return repoBlog.Find(x => x.BlogId == id);
        }

        public int BlogUpdate(Blog p)
        {
            Blog blog = repoBlog.Find(x => x.BlogId == p.BlogId);
            blog.BlogTitle = p.BlogTitle;
            blog.BlogImage = p.BlogImage;
            blog.BlogDate = p.BlogDate;
            blog.BlogContent = p.BlogContent;
            blog.CategoryId = p.CategoryId;
            blog.AuthorId = p.AuthorId;
            return repoBlog.Update(blog);
        }
    }
}
